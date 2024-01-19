using AutoMapper;
using domain;
using domain.shared.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using OfficeOpenXml;
using repository.AppRepositories;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs.Attendance;
using service.contract.DTOs.Class;
using service.contract.DTOs.Score;
using service.contract.DTOs.Student;
using service.contract.DTOs.SubjectComponent;
using service.contract.DTOs.Teacher;
using service.contract.IAppServices;
using System;
using System.Collections.Immutable;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;

namespace service.AppServices
{
    public class ClassService : AppCRUDDefaultKeyService<ClassDTO, CreateClassDTO, UpdateClassDTO, Class>, IClassService
    {
        readonly IFeeDetailRepository feeDetailRepository;
        readonly IScoreRepository scoreRepository;
        readonly ISubjectRepository subjectRepository;
        readonly IAttedanceRepository attedanceRepository;
        readonly IStudentRepository studentRepository;
        readonly IClassRepository classRepository;
        readonly IRoomRepository roomRepository;
        readonly ISlotRepository slotRepository;
        readonly ITimeTableRepository timeTableRepository;
        readonly IWeekRepository weekRepository;
        readonly ISlotTimeTableAtWeekRepository slotTimeTableAtWeekRepository;
        readonly ITeacherRepository teacherRepository;
        public ClassService(ITeacherRepository teacherRepository, ISlotTimeTableAtWeekRepository slotTimeTableAtWeekRepository, IWeekRepository weekRepository, ITimeTableRepository timeTableRepository, ISlotRepository slotRepository, IRoomRepository roomRepository, IClassRepository classRepository, IStudentRepository studentRepository, IScoreRepository scoreRepository, IAttedanceRepository attedanceRepository, ISubjectRepository subjectRepository, IFeeDetailRepository feeDetailRepository, IClassRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
            this.feeDetailRepository = feeDetailRepository;
            this.scoreRepository = scoreRepository;
            this.subjectRepository = subjectRepository;
            this.attedanceRepository = attedanceRepository;
            this.studentRepository = studentRepository;
            this.classRepository = classRepository;
            this.roomRepository = roomRepository;
            this.slotRepository = slotRepository;
            this.timeTableRepository = timeTableRepository;
            this.weekRepository = weekRepository;
            this.slotTimeTableAtWeekRepository = slotTimeTableAtWeekRepository;
            this.teacherRepository = teacherRepository;
        }
        public async Task<List<StudentAttendance>> GetAttendancesByClass(Guid classId, DateTime dateTime)
        {
            var result = await attedanceRepository.GetAll().Result
               .Include(a => a.FeeDetail)
                   .ThenInclude(fd => fd.StudentSemester)
                       .ThenInclude(ss => ss.Student)
               .Where(a => a.FeeDetail.ClassId == classId && a.Date == dateTime)
               .Select(a => new StudentAttendance
               {
                   student = new StudentDTO
                   {
                       Id = a.FeeDetail.StudentSemester.Student.Id,
                       FullName = a.FeeDetail.StudentSemester.Student.FullName,
                   },
                   attendance = new AttendanceDTO
                   {
                       Id = a.Id,
                       IsAttendance = a.IsAttendance,
                   }
               })
               .ToListAsync();

            return Mapper.Map<List<StudentAttendance>>(result);
        }

        public async Task ClassForNewSemester()
        {
            var subjects = subjectRepository.GetAll().Result.Include(s => s.SubjectComponents).Include(s => s.FeeDetails).ThenInclude(fd => fd.StudentSemester).ThenInclude(ss => ss.Semester).ToList();
            var currentSemester = subjects.FirstOrDefault().FeeDetails.Where(fd => fd.StudentSemester.IsNow == true).Select(fd => fd.StudentSemester.Semester).FirstOrDefault();
            var rooms = await roomRepository.GetAll().Result.ToListAsync();
            var startDate = new DateTime(DateTime.Now.Year, currentSemester.StartMonth, currentSemester.StartDay);
            var endDate = new DateTime(DateTime.Now.Year, currentSemester.EndMonth, currentSemester.EndDay);

            foreach (var subject in subjects)
            {
                var fees = feeDetailRepository.GetAll().Result.Include(fd => fd.Attendances).Include(fd => fd.StudentSemester).ThenInclude(ss => ss.Student).Where(fd => fd.StudentSemester.IsNow == true && fd.SubjectId == subject.Id && fd.ClassId == null).ToList();
                foreach (var fee in fees)
                {
                    foreach (var sc in subject.SubjectComponents)
                    {
                        Score score = new()
                        {
                            Id = Guid.NewGuid(),
                            SubjectComponentID = sc.Id,
                            SubjectComponent = sc,
                            StudentId = fee.StudentSemester.Student.Id,
                            Student = fee.StudentSemester.Student,
                            Value = null,
                        };
                        await scoreRepository.Create(score);
                        await scoreRepository.SaveChange();
                    }
                }
                var index = 0;
                while (fees.Any())
                {
                    Class newClass = new()
                    {
                        StartDate = startDate,
                        EndDate = endDate,
                        Id = Guid.NewGuid(),
                        ClassCode = $"{subject.SubjectCode}_{index}"
                    };
                    await classRepository.Create(newClass);
                    await this.classRepository.SaveChange();
                    index++;

                    var allSlotTimeTables = await slotTimeTableAtWeekRepository.GetAll().Result.Include(staw => staw.Slot).Include(staw => staw.Timetable).Include(staw => staw.Week).ToListAsync();
                    var assignedSlotTimeTables = await GetAssignedSlotTimeTablesForCurrentSemester(currentSemester);

                    var unassignedSlotTimeTables = allSlotTimeTables
             .Where(st => !assignedSlotTimeTables.Any(assigned => assigned.Id == st.Id))
             .ToList();

                    var selectedSlotTimeTables = new List<SlotTimeTableAtWeek>();
                    var selectedFee = fees.Take(30);

                    var selectedGroups = unassignedSlotTimeTables.GroupBy(st => new { st.SlotId, st.TimetableId }).Take(2);
                    foreach (var feeDetail in selectedFee)
                    {
                        foreach (var group in selectedGroups)
                        {

                            foreach (var slotTimeTable in group)
                            {
                                selectedSlotTimeTables.Add(slotTimeTable);

                                DateTime currentDate = startDate;

                                while (currentDate <= endDate)
                                {
                                    var a = currentDate.DayOfWeek.ToString().Substring(0, 3);
                                    if (slotTimeTable.Timetable.WeekDay == currentDate.DayOfWeek.ToString().Substring(0, 3))
                                    {
                                        if (GetWeekNumber(currentDate) == slotTimeTable.Week.WeekName)
                                        {

                                            Attendance attendance = new Attendance
                                            {
                                                SlotTimeTableAtWeek = slotTimeTable,
                                                FeeDetail = feeDetail,
                                                IsAttendance = null,
                                                Date = currentDate
                                            };
                                            await attedanceRepository.Create(attendance);
                                            await attedanceRepository.SaveChange();
                                        }
                                    }

                                    currentDate = currentDate.AddDays(1);
                                }
                                feeDetail.Class = newClass;
                                feeDetail.ClassId = newClass.Id;
                            }

                        }
                    }
                    var selectedRoom = rooms.FirstOrDefault(room => !room.RoomAttendances.Any(ra => ra.FeeDetail.SubjectId == subject.Id &&
                    selectedSlotTimeTables.Any(stt => ra.SlotTimeTableAtWeek.SlotId == stt.SlotId && ra.SlotTimeTableAtWeek.TimetableId == stt.TimetableId)));

                    foreach (var feeDetail in selectedFee)
                    {
                        foreach (var attendance in feeDetail.Attendances)
                        {
                            attendance.Room = selectedRoom;
                            await attedanceRepository.Update(attendance);
                            await attedanceRepository.SaveChange();
                        }
                    }

                    var teacher = await GetAvailableTeacherForClass(newClass, selectedSlotTimeTables, subject.Id);
                    newClass.Teacher = teacher;
                    newClass.TeacherId = teacher.Id;
                    await classRepository.Update(newClass);
                    fees.RemoveAll(st => selectedFee.Any(selected => selected.Id == st.Id));

                    unassignedSlotTimeTables.RemoveAll(st => selectedSlotTimeTables.Any(selected => selected.Id == st.Id));

                }

            }

        }

        public async Task<Teacher> GetAvailableTeacherForClass(Class newClass, List<SlotTimeTableAtWeek> timetable, Guid subjectId)
        {
            var allTeachers = await teacherRepository.GetAll().Result.ToListAsync();


            var availableTeachers = allTeachers.Where(teacher =>
        !teacher.Classes.Any(c => c.StartDate == newClass.StartDate && c.EndDate == newClass.EndDate &&
            c.FeeDetails.Any(fd => fd.SubjectId == subjectId && fd.Attendances.Any(att =>
                  timetable.Any(slt => att.SlotTimeTableAtWeek.TimetableId == slt.TimetableId &&
                    att.SlotTimeTableAtWeek.SlotId == slt.SlotId))))).ToList();

            var random = new Random();
            var selectedTeacher = availableTeachers.OrderBy(x => random.Next()).FirstOrDefault();

            return selectedTeacher;
        }



        private async Task<List<SlotTimeTableAtWeek>> GetAssignedSlotTimeTablesForCurrentSemester(Semester semester)
        {
            var assignedSlotTimeTables = await attedanceRepository.GetAll().Result.Include(a => a.SlotTimeTableAtWeek).ThenInclude(staw => staw.Week)
                .Include(a => a.SlotTimeTableAtWeek).ThenInclude(staw => staw.Slot).Include(a => a.SlotTimeTableAtWeek).ThenInclude(staw => staw.Week)
                .Where(a => a.SlotTimeTableAtWeek.Attendances.Any(a => a.FeeDetail.StudentSemester.SemesterId == semester.Id))
                .Select(a => a.SlotTimeTableAtWeek)
                .Distinct()
                .ToListAsync();

            return assignedSlotTimeTables;
        }

        public static int GetWeekNumber(DateTime date)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }

        public async Task<TeacherDTO> GetTeacher(Guid classId)
        {
            return Mapper.Map<TeacherDTO>((await (Repository as IClassRepository).Find(classId)).Teacher);
        }

        public async Task<List<ClassDTO>> GetClassesByTeacher(Guid teacherId)
        {
            var result = base.Repository.GetAll().Result.Include(c => c.FeeDetails).ThenInclude(fd => fd.StudentSemester).Where(c => c.TeacherId == teacherId && c.StartDate <= DateTime.Now && c.EndDate >= DateTime.Now).ToList();
            return Mapper.Map<List<ClassDTO>>(result);
        }

        public async Task<List<DateTime?>> GetDates(Guid classId)
        {
            return await attedanceRepository.GetAll().Result
               .Include(a => a.FeeDetail)
               .Where(a => a.FeeDetail.ClassId == classId).Select(a => a.Date).ToListAsync();
        }

        public async Task<List<StudentScoreDTO>> GetStudentsByClass(Guid classId)
        {
            var result = await feeDetailRepository.GetAll().Result
                     .Include(fd => fd.StudentSemester)
                     .ThenInclude(ss => ss.Student)
                     .Include(fd => fd.Subject)
                         .ThenInclude(s => s.SubjectComponents)
                                     .Where(fd => fd.ClassId == classId)
                .GroupBy(fd => new { fd.StudentSemester.StudentId, fd.SubjectId })
                     .Select(group => new StudentScoreDTO
                     {
                         StudentId = group.First().StudentSemester.Student.Id,
                         StudentName = group.First().StudentSemester.Student.FullName,
                         SubjectComponents = group.First().Subject.SubjectComponents
                            .Select(sc => new SubjectComponentDTO
                            {
                                Id = sc.Id,
                                Name = sc.Name,
                                Weight = sc.Weight,
                                Comment = sc.Comment,
                                SubjectID = group.Key.SubjectId,
                                Scores = scoreRepository.Entities
                                    .Where(s => s.StudentId == group.Key.StudentId && s.SubjectComponentID == sc.Id)
                                    .Select(s => new ScoreDTO
                                    {
                                        Value = s.Value,
                                        SubjectComponentID = s.SubjectComponentID,
                                        StudentId = s.StudentId
                                    })
                                    .ToList()
                            })
                            .ToList()
                     })
                    .ToListAsync();
            return result;
        }

        public async Task<List<SubjectComponentDTO>> GetSubjectComponentsByClass(Guid classId)
        {
            var result = subjectRepository.GetAll().Result.Include(s => s.FeeDetails).Include(s => s.SubjectComponents).
                Where(s => s.FeeDetails.Any(fd => fd.ClassId == classId))
                   .SelectMany(s => s.SubjectComponents)
                    .ToList();

            return Mapper.Map<List<SubjectComponentDTO>>(result);
        }

        public async Task SaveAttendance(List<TakeAttendance> result)
        {
            foreach (var item in result)
            {
                var attendance = attedanceRepository.GetAll().Result.FirstOrDefault(a => a.Id == item.AttendanceId);
                attendance.IsAttendance = item.IsAttendance;
                attedanceRepository.Update(attendance);
            }
        }
        public async Task SaveScores(List<TakeScore> result)
        {
            foreach (var item in result)
            {
                foreach (var subjectComponent in item.Scores)
                {
                    var score = scoreRepository.GetAll().Result.Include(s => s.SubjectComponent).
                        Where(s => s.SubjectComponent.Name.Equals(subjectComponent.Name) && s.StudentId == item.StudentId)
                        .OrderByDescending(x => x.CreatedAt).FirstOrDefault();
                    score.Value = string.IsNullOrEmpty(subjectComponent.Value) ? (double?)null : double.Parse(subjectComponent.Value);
                    scoreRepository.Update(score);
                }
            }
        }

        public async Task<ClassInformation> GetClassInformation(Guid classId)
        {
            return classRepository.GetAll().Result.Include(c => c.Teacher)
                .Include(c => c.FeeDetails).ThenInclude(fd => fd.StudentSemester).ThenInclude(ss => ss.Student).ThenInclude(s => s.Major)
                .Include(c => c.FeeDetails).ThenInclude(fd => fd.Subject).
                Select(c => new ClassInformation()
                {
                    ClassCode = c.ClassCode,
                    TeacherName = c.Teacher.FullName,
                    SubjectName = c.FeeDetails.FirstOrDefault().Subject.SubjectName,
                    Students = Mapper.Map<List<StudentDTO>>(c.FeeDetails.Select(fd => fd.StudentSemester.Student).ToList())
                }).FirstOrDefault();
        }

        public async Task<byte[]> GetScoreExcelTemplate(Guid classId)
        {
            var querable = await this.Repository.GetAll();
            var classInfo = querable
            .Include(c => c.FeeDetails)
            .ThenInclude(c => c.StudentSemester)
            .ThenInclude(c => c.Student)
            .Include(c => c.FeeDetails)
            .ThenInclude(f => f.Subject)
            .ThenInclude(f => f.SubjectComponents)
            .FirstOrDefault(c => c.Id == classId)
            ?? throw new ClientException("Không tìm thấy thông tin lớp");

            var student = classInfo.FeeDetails.Select(f => f.StudentSemester.Student).ToList();
            var subjectComponent = classInfo.FeeDetails.First().Subject.SubjectComponents.OrderBy(s => s.CreatedAt).ToList();
            using var excelPackage = new ExcelPackage();
            var workSheet = excelPackage.Workbook.Worksheets.Add(classInfo.ClassCode);
            workSheet.Cells[1, 1].Value = "Mã sinh viên";
            workSheet.Cells[1, 2].Value = "Tên sinh viên";


            for (int i = 0; i < subjectComponent.Count; i++)
            {
                workSheet.Cells[1, i + 3].Value = subjectComponent.ElementAt(i).Name;
            }
            for (int i = 0; i < student.Count(); i++)
            {
                workSheet.Cells[i + 2, 1].Value = student.ElementAt(i).Username;
                workSheet.Cells[i + 2, 2].Value = student.ElementAt(i).FullName;
            }
            for (int i = 1; i <= workSheet.Columns.Count(); i++)
            {
                workSheet.Column(i).AutoFit();
            }
            return excelPackage.GetAsByteArray();

        }

        public async Task UploadScoreExcel(Guid classId, ExcelPackage excelScore)
        {
            var querable = await this.Repository.GetAll();
            var classInfo = querable
            .Include(c => c.FeeDetails)
            .ThenInclude(c => c.StudentSemester)
            .ThenInclude(c => c.Student)
            .Include(c => c.FeeDetails)
            .ThenInclude(f => f.Subject)
            .ThenInclude(f => f.SubjectComponents)
            .FirstOrDefault(c => c.Id == classId)
            ?? throw new ClientException("Không tìm thấy thông tin lớp");
            var student = classInfo.FeeDetails.Select(f => f.StudentSemester.Student).ToList();
            var subjectComponent = classInfo.FeeDetails.First().Subject.SubjectComponents.OrderBy(s => s.CreatedAt).ToList();

            var classScore = excelScore.Workbook.Worksheets.FirstOrDefault(w => w.Name == classInfo.ClassCode)
            ?? throw new ClientException("File excel không tồn tại sheet có tên của lớp đang chọn");
            List<TakeScore> scores = new List<TakeScore>();
            for (int i = 2; i <= classScore.Rows.Count(); i++)
            {
                TakeScore takeScore = new TakeScore()
                {
                    ClassId = classId,
                    StudentId = (student.FirstOrDefault(s => s.Username == classScore.Cells[i, 1].Value.ToString())
                       ?? throw new ClientException($"Không tìm thấy thông tin sinh viên tại dòng {i} trong hệ thống")).Id,
                };
                for (int j = 3; j <= subjectComponent.Count; j++)
                {
                    var name = subjectComponent.ElementAt(j - 3).Name;
                    var value = classScore.Cells[i, j].Value?.ToString();
                    ScoreValue score = new ScoreValue()
                    {
                        Name = name,
                        Value = value
                    };
                    takeScore.Scores.Add(score);
                }
                scores.Add(takeScore);
            }
            await this.SaveScores(scores);

        }
    }
}

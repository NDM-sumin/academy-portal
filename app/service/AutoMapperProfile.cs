using AutoMapper;
using domain;
using domain.shared.AppSettings;
using service.contract.DTOs.Account;
using service.contract.DTOs.Class;
using service.contract.DTOs.Email;
using service.contract.DTOs.FeeDetail;
using service.contract.DTOs.Major;
using service.contract.DTOs.Score;
using service.contract.DTOs.Semester;
using service.contract.DTOs.Student;
using service.contract.DTOs.Subject;
using service.contract.DTOs.Teacher;

namespace service
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Account, AccountDTO>().ReverseMap();
            this.CreateMap<Account, CreateAccountDTO>().ReverseMap();
            this.CreateMap<Account, UpdateAccountDTO>().ReverseMap();
            this.CreateMap<Account, AccountNoPasswordDTO>().ReverseMap();

            this.CreateMap<Class, ClassDTO>().ReverseMap();
            this.CreateMap<Class, CreateClassDTO>().ReverseMap();
            this.CreateMap<Class, UpdateClassDTO>().ReverseMap();

            this.CreateMap<Major, MajorDTO>().ReverseMap();
            this.CreateMap<Major, CreateMajorDTO>().ReverseMap();
            this.CreateMap<Major, UpdateMajorDTO>().ReverseMap();

            this.CreateMap<Semester, SemesterDTO>().ReverseMap();
            this.CreateMap<Semester, CreateSemesterDTO>().ReverseMap();
            this.CreateMap<Semester, UpdateSemesterDTO>().ReverseMap();

            this.CreateMap<Subject, SubjectDTO>().ReverseMap();
            this.CreateMap<Subject, CreateSubjectDTO>().ReverseMap();
            this.CreateMap<Subject, UpdateSubjectDTO>().ReverseMap();

            this.CreateMap<Score, ScoreDTO>().ReverseMap();
            this.CreateMap<Score, CreateScoreDTO>().ReverseMap();
            this.CreateMap<Score, UpdateScoreDTO>().ReverseMap();

            this.CreateMap<Student, StudentDTO>().ReverseMap();
            this.CreateMap<Student, CreateStudentDTO>().ReverseMap();
            this.CreateMap<Student, UpdateStudentDTO>().ReverseMap();

            this.CreateMap<Teacher, TeacherDTO>().ReverseMap();
            this.CreateMap<Teacher, CreateTeacherDTO>().ReverseMap();
            this.CreateMap<Teacher, UpdateTeacherDTO>().ReverseMap();

            this.CreateMap<FeeDetail, FeeDetailDTO>().ReverseMap();
            this.CreateMap<FeeDetail, CreateFeeDetailDTO>().ReverseMap();

            this.CreateMap<MailConfiguration, SmtpConfigModel>().ReverseMap();

        }
    }
}

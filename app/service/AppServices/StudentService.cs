using AutoMapper;
using domain;
using domain.shared.AppSettings;
using Microsoft.Extensions.Options;
using OfficeOpenXml;
using repository.AppRepositories;
using repository.contract.IAppRepositories.Base;
using service.AppServices.Base;
using service.contract.DTOs.Account;
using service.contract.DTOs.FeeDetail;
using service.contract.DTOs.Student;
using service.contract.DTOs.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.AppServices
{
    public class StudentService : AppCRUDDefaultKeyService<StudentDTO, CreateStudentDTO, UpdateStudentDTO, Student>, IStudentService
    {
        readonly JwtConfiguration _jwtConfiguration;
        private IStudentRepository _studentRepository;
        public StudentService(IStudentRepository genericRepository, IMapper mapper,IOptions<JwtConfiguration> jwtConfiguration) : base(genericRepository, mapper)
        {
            _studentRepository = genericRepository;
            _jwtConfiguration = jwtConfiguration.Value;
        }

        public List<StudentDTO> ImportStudentsFromExcel(string filePath)
        {
            var students = new List<StudentDTO>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];

                for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                {
                    students.Add(new StudentDTO
                    {
                        Username = worksheet.Cells[row, 1].Value.ToString(),
                        FullName = worksheet.Cells[row, 2].Value.ToString(),
                        Email = worksheet.Cells[row, 3].Value.ToString(),
                        Password = worksheet.Cells[row, 4].Value.ToString(),
                        Dob = DateTime.Parse(worksheet.Cells[row, 5].Value.ToString()),
                        Gender = Convert.ToBoolean(worksheet.Cells[row, 6].Value),
                        Phone = worksheet.Cells[row, 7].Value.ToString(),
                    });
                }
            }

            return students;
        }

        public override Task<StudentDTO> Create(CreateStudentDTO entityDto)
        {
            entityDto.Password = Guid.NewGuid().ToString();
            HashService hashService = new HashService(entityDto.Password, _jwtConfiguration.HashSalt);
            entityDto.Password = hashService.EncryptedPassword;
            return base.Create(entityDto);
        }

        public async Task RegisterSubject(CreateFeeDetailDTO createFeeDetailDTO)
        {
            
        }
    }
}

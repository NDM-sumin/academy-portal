using domain;
using service.contract.DTOs.Account;
using service.contract.DTOs.FeeDetail;
using service.contract.DTOs.Student;
using service.contract.DTOs.Subject;
using service.contract.IAppServices.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.AppServices
{
    public interface IStudentService : IAppCRUDDefaultKeyService<StudentDTO, CreateStudentDTO, UpdateStudentDTO, Student>
    {
        Task RegisterSubject(CreateFeeDetailDTO createFeeDetailDTO);
    }
}

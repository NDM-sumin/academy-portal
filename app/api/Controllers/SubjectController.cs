using api.Controllers.Base;
using domain;
using domain.shared.Exceptions;
using Microsoft.AspNetCore.Mvc;
using service.contract.DTOs.MajorSubject;
using service.contract.DTOs.Subject;
using service.contract.DTOs.VNPay;
using service.contract.IAppServices;

namespace api.Controllers
{
    public class SubjectController : AppCRUDDefaultKeyController<SubjectDTO, CreateSubjectDTO, UpdateSubjectDTO, Subject>
    {
        readonly IStudentSemesterService studentSemesterService;
        readonly IMajorSubjectService majorSubjectService;
        readonly IVnPayService vnPayService;
        readonly IAccountService accountService;
        readonly IPaymentTransactionService paymentTransactionService;
        public SubjectController(ISubjectService appCRUDService,
        IStudentSemesterService studentSemesterService,
        IVnPayService vnPayService,
        IMajorSubjectService majorSubjectService,
        IAccountService accountService,
        IPaymentTransactionService paymentTransactionService) : base(appCRUDService)
        {
            this.studentSemesterService = studentSemesterService;
            this.majorSubjectService = majorSubjectService;
            this.vnPayService= vnPayService;
            this.accountService =  accountService;
            this.paymentTransactionService = paymentTransactionService;
        }
        [HttpGet]

        public async Task<PaymentTransactionDto> GetPayUrl([FromQuery] List<Guid> subjectIds){
            if(subjectIds .Count == 0){
                throw new ClientException(5006);
            }
            List<SubjectDTO> subjects = new List<SubjectDTO>();
            foreach(var id in subjectIds)
            {
                subjects.Add(( await (appCRUDService as ISubjectService).Get(id)));
            }
            var user = await accountService.GetAccountById(GetUserId());
            CreatePayUrlDto createPayUrlDto = new CreatePayUrlDto(){
                Amount = subjects.Sum(s => s.Price),
                OrderInfo="Thanh toan hoc phi sinh vien " + user.FullName ,
                Expires=20
            };
         var url=   vnPayService
            .InitRequestParams(GetIpAddress(), out string transactionId)
            .CreateRequestUrl(createPayUrlDto, out string secureHash);
            PaymentTransactionDto paymentTransactionDto = new PaymentTransactionDto(){
               
                TxnRef = transactionId,
                Amount = createPayUrlDto.Amount,
                OrderInfo = createPayUrlDto.OrderInfo,
                SecureHash = secureHash,
                PayUrl = url
            };
await paymentTransactionService.Create(paymentTransactionDto);


return paymentTransactionDto;


        }
        
        public override async Task<SubjectDTO> Create(CreateSubjectDTO entityDto)
        {
            var data = await base.Create(entityDto);
            foreach (var majorId in entityDto.MajorIds)
            {

                await majorSubjectService.Create(new MajorSubjectDto()
                {
                    MajorId = majorId,
                    SemesterId = entityDto.SemesterId,
                    SubjectId = entityDto.Id
                });
            }
            return data;

        }
        public override async Task<SubjectDTO> Update(UpdateSubjectDTO updateSubjectDTO)
        {
            var data = await base.Update(updateSubjectDTO);
            await majorSubjectService.DeleteBySubjectId(updateSubjectDTO.Id);
            foreach (var majorId in updateSubjectDTO.MajorIds)
            {

                await majorSubjectService.Create(new MajorSubjectDto()
                {
                    MajorId = majorId,
                    SemesterId = updateSubjectDTO.SemesterId,
                    SubjectId = updateSubjectDTO.Id
                });
            }
            return data;
        }

        [HttpGet("GetRegisterableSubjects")]
        public async Task<List<SubjectDTO>> GetRegisterableSubjects()
        {
            return await (appCRUDService as ISubjectService).GetRegisterableSubjects(this.GetUserId());
        }

        [HttpGet("GetSubjects/{semesterId}/{studentId}")]
        public async Task<List<SubjectDTO>> GetSubjects(Guid semesterId, Guid studentId)
        {
            return await studentSemesterService.GetSubjects(semesterId, studentId);
        }

    }
}

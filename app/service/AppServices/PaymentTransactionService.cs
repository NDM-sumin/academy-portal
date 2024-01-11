


using AutoMapper;
using domain;
using repository.contract.IAppRepositories;
using repository.contract.IAppRepositories.Base;
using service.AppServices.Base;
using service.contract.DTOs.VNPay;
using service.contract.IAppServices;
using service.contract.IAppServices.Base;

namespace service.AppServices{

    public class PaymentTransactionService : AppCRUDDefaultKeyService<PaymentTransactionDto, PaymentTransactionDto, PaymentTransactionDto, PaymentTransaction>, IPaymentTransactionService

    {
        public PaymentTransactionService(IPaymentTransactionRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}
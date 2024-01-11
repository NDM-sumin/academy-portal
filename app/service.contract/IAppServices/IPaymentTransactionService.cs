
using domain;
using service.contract.DTOs.VNPay;
using service.contract.IAppServices.Base;

namespace service.contract.IAppServices
{

    public interface IPaymentTransactionService : IAppCRUDDefaultKeyService<PaymentTransactionDto, PaymentTransactionDto, PaymentTransactionDto, PaymentTransaction>{
        
    }
}
using domain;
using service.contract.DTOs.VNPay;
using service.contract.IAppServices.Base;

namespace service.contract.IAppServices
{
    public interface IVnPayService
    {
        IVnPayService InitRequestParams(string customerIpAddress, out string transactionId);
        string CreateRequestUrl(CreatePayUrlDto createPayUrlDto, out string secureHash);
    }
}

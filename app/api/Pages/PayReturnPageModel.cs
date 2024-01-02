using api.Hubs;
using AutoMapper;
using domain.shared.AppSettings;
using domain.shared.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using repository.contract.IAppRepositories;
using service.contract.DTOs.VNPay;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace api.Pages
{
    public class PayReturnPageModel : PageModel
    {
        [FromQuery(Name = "vnp_TmnCode")]
        public string Vnp_TmnCode { get; set; } = null!;
        [FromQuery(Name = "vnp_Amount")]
        public decimal Vnp_Amount { get; set; }
        [FromQuery(Name = "vnp_BankCode")]
        public string Vnp_BankCode { get; set; } = null!;
        [FromQuery(Name = "vnp_BankTranNo")]
        public string? Vnp_BankTranNo { get; set; }
        [FromQuery(Name = "vnp_CardType")]
        public string? Vnp_CardType { get; set; }
        [FromQuery(Name = "vnp_PayDate")]
        public long Vnp_PayDate { get; set; }
        [FromQuery(Name = "vnp_OrderInfo")]
        public string Vnp_OrderInfo { get; set; } = null!;
        [FromQuery(Name = "vnp_TransactionNo")]
        public int Vnp_TransactionNo { get; set; }
        [FromQuery(Name = "vnp_ResponseCode")]
        public int Vnp_ResponseCode { get; set; }
        [FromQuery(Name = "vnp_TransactionStatus")]
        public int Vnp_TransactionStatus { get; set; }
        [FromQuery(Name = "vnp_TxnRef")]
        public string Vnp_TxnRef { get; set; } = null!;
        [FromQuery(Name = "vnp_SecureHashType")]
        public string? Vnp_SecureHashType { get; set; }
        [FromQuery(Name = "vnp_SecureHash")]
        public string Vnp_SecureHash { get; set; } = null!;

        readonly VNPayConfiguration vnPayConfig;
        readonly IHubContext<PaymentHub> paymentHub;
        readonly IPaymentTransactionRepository paymentTransactionRepository;
        readonly IMapper mapper;
        public PayReturnPageModel(IOptions<VNPayConfiguration> options,
           IHubContext<PaymentHub> paymentHub,
            IPaymentTransactionRepository paymentTransactionRepository,
        IMapper mapper)
        {
            this.vnPayConfig = options.Value;
            this.paymentHub = paymentHub;
            this.paymentTransactionRepository = paymentTransactionRepository;
            this.mapper = mapper;
        }

        public async Task OnGet()
        {
            if (string.IsNullOrEmpty(this.Request.QueryString.Value))
            {
                return;
            }
            var queryDictionary = this.Request.Query.ToDictionary(c => c.Key, c => c.Value.ToString());
            bool isValid = VNPayHelper.ValidateSignature(queryDictionary, vnPayConfig.HashSecret);

            if (!isValid)
            {

            }
            bool isSuccess = Vnp_ResponseCode == 0 && Vnp_TransactionStatus == 0;

            var paymentTransaction = await paymentTransactionRepository.FindByTxnRef(Vnp_TxnRef);
            paymentTransaction.TransactionStatus = this.Vnp_TransactionStatus;
            paymentTransaction.TransactionNo = this.Vnp_TransactionNo;
            paymentTransaction.BankTranNo = this.Vnp_BankTranNo;
            paymentTransaction.BankCode = this.Vnp_BankCode;
            paymentTransaction.CardType = this.Vnp_CardType;
            if (DateTime.TryParseExact(this.Vnp_PayDate.ToString(),
                                        "yyyyMMddHHmmss",
                                        System.Globalization.CultureInfo.InvariantCulture,
                                        System.Globalization.DateTimeStyles.None,
                                        out DateTime payDate))
            {
                paymentTransaction.PayDate = payDate;
            }
            paymentTransaction.OrderInfo = this.Vnp_OrderInfo;
            paymentTransaction.ResponseCode = this.Vnp_ResponseCode;
            paymentTransaction.TransactionStatus = this.Vnp_TransactionStatus;
            paymentTransaction.SecureHashType = this.Vnp_SecureHashType;
            await this.paymentTransactionRepository.Update(paymentTransaction);

            var paymentTransactionDto = mapper.Map<PaymentTransactionDto>(paymentTransaction);

            /* var parkingTransaction = await parkingTransactionRepository.Find(paymentTransaction.BookingId);
             if (!isSuccess)
             {

                 parkingTransaction.StatusId = (int)ParkingTransactionStatusEnum.BOOKING_PAID_FAILED;
                 await parkingTransactionRepository.Update(parkingTransaction);
             }
             if (!string.IsNullOrEmpty(parkingTransaction.PromoCode))
             {
                 var promoCode = await this.promoCodeRepository.GetByCode(parkingTransaction.PromoCode, parkingTransaction.ParkingZoneId);
                 if (promoCode != null)
                 {
                     promoCode.NumberOfUses -= 1;
                     await this.promoCodeRepository.Update(promoCode);
                 }

             }


             await this.paymentTransactionRepository.SaveChange();
             if (isSuccess)
             {
                 try
                 {
                     await this.parkingTransactionRepository.SendBookedEmail(parkingTransaction, paymentTransaction);
                 }
                 catch (System.Exception)
                 {
                 }

             }*/
            await paymentHub.Clients.Client(paymentTransaction.ConnectionId).SendAsync("ReceivePaidStatus", JsonSerializer.Serialize(paymentTransactionDto, new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles }));

        }

    }
}

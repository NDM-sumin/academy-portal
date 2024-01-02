namespace service.contract.DTOs.VNPay
{
    public class PaymentStatusDto
    {
        public int Code { get; set; }
        public string Message { get; set; } = null!;
    }
}

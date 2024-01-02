namespace service.contract.DTOs.VNPay
{
    public class CreatePayUrlDto
    {
        /// <summary>
        /// Order information content
        /// </summary>
        public string OrderInfo { get; set; } = null!;
        public decimal Amount { get; set; }
        /// <summary>
        /// Expires time of url in minutes
        /// </summary>
        public int Expires { get; set; }
    }
}

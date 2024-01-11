using System.ComponentModel.DataAnnotations.Schema;

namespace domain
{
    public class PaymentTransaction : AppEntityDefaultKey
    {
        public PaymentTransaction(){
            FeeDetail = new   HashSet<FeeDetail>();
        }
        public int? TransactionNo { get; set; }
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
        public string? BankCode { get; set; }
        public string? BankTranNo { get; set; }
        public string? CardType { get; set; }
        public DateTime? PayDate { get; set; }
        public string OrderInfo { get; set; } = null!;
        public int? ResponseCode { get; set; }
        public int? TransactionStatus { get; set; }
        public string TxnRef { get; set; } = null!;
        public string? SecureHashType { get; set; }
        public string SecureHash { get; set; } = null!;
        public string? ConnectionId { get; set; }

        public virtual ICollection<FeeDetail> FeeDetail { get; set; }

    }
}

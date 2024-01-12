using System.ComponentModel.DataAnnotations.Schema;

namespace domain
{
    public class Score : AppEntityDefaultKey
    {
        public double? Value { get; set; }
        public Guid SubjectComponentID { get; set; }
        public Guid FeeDetailId { get; set; }
        [ForeignKey(nameof(FeeDetailId))]
        public virtual FeeDetail FeeDetail { get; set; } = null!;

        [ForeignKey(nameof(SubjectComponentID))]
        public virtual SubjectComponent SubjectComponent { get; set; } = null!;
    }
}

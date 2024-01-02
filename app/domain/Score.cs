using System.ComponentModel.DataAnnotations.Schema;

namespace domain
{
    public class Score : AppEntityDefaultKey
    {
        public double Value { get; set; }
        public Guid SubjectComponentID { get; set; }
        public Guid StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; } = null!;

        [ForeignKey(nameof(SubjectComponentID))]
        public virtual SubjectComponent SubjectComponent { get; set; } = null!;
    }
}

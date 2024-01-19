using System.ComponentModel.DataAnnotations.Schema;

namespace domain
{
    public class SubjectComponent : AppEntityDefaultKey
    {
        public SubjectComponent()
        {
            Scores = new HashSet<Score>();
        }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public double Weight { get; set; }
        public string? Comment { get; set; }
        public Guid SubjectID { get; set; }
        [ForeignKey(nameof(SubjectID))]
        public virtual Subject Subject { get; set; } = null!;
        public virtual ICollection<Score> Scores { get; set; }
    }
}

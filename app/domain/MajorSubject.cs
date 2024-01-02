using System.ComponentModel.DataAnnotations.Schema;

namespace domain
{
    public class MajorSubject : AppEntityDefaultKey
    {
        public MajorSubject()
        {
           
        }
        public Guid MajorId { get; set; }
        public Guid SubjectId { get; set; }
        [ForeignKey(nameof(MajorId))]
        public virtual Major Major { get; set; } = null!;
        [ForeignKey(nameof(SubjectId))]
        public virtual Subject Subject { get; set; } = null!;

        public Guid SemesterId {  get; set; }
        [ForeignKey(nameof(SemesterId))]
        public virtual Semester Semester { get; set; } = null!;

      
    }
}

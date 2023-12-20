using System.ComponentModel.DataAnnotations;

namespace domain
{
    public class AppEntityAbstractKey<TKey> : AppEntity
        where TKey : struct
    {
        [Key]
        public TKey Id { get; set; }

    }
}

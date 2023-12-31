using System.ComponentModel.DataAnnotations;

namespace domain.Base
{
    public class AppEntityAbstractKey<TKey> : AppEntity
        where TKey : struct
    {
        [Key]
        public TKey Id { get; set; }

    }
}

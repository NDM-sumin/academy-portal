namespace domain
{
    public class AppEntity
    {

        public AppEntity()
        {
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
        }
        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}

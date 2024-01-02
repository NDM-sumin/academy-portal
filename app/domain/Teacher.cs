namespace domain
{
    public class Teacher : Account
    {
        public Teacher()
        {
            Classes = new HashSet<Class>();
            Role = shared.Enums.Role.Teacher;
        }
        public virtual ICollection<Class> Classes { get; set; }
    }
}

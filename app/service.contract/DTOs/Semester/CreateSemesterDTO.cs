namespace service.contract.DTOs.Semester
{
    public class CreateSemesterDTO: AppEntityDefaultKeyDTO
    {
        public string SemesterCode { get; set; } = null!;
        public string SemesterName { get; set; } = null!;

        public int StartMonth { get; set; }
        public int StartDay { get; set; }
        public int EndMonth { get; set; }
        public int EndDay { get; set; }

        public Guid? PrevSemesterId { get; set; }
    }
}

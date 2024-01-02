namespace service.contract.DTOs.Major
{
    public class UpdateMajorDTO : AppEntityDefaultKeyDTO
    {
        public string MajorCode { get; set; } = null!;
        public string MajorName { get; set; } = null!;
    }
}

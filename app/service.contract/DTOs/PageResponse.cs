namespace service.contract.DTOs
{
    public class PageResponse<T>
    {
        public PageResponse()
        {
            Items = Enumerable.Empty<T>();
        }
        public long TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}

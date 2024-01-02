﻿namespace service.contract.DTOs
{
    public class PageResponse<T>
    {
        public PageResponse()
        {
            Items = Enumerable.Empty<T>().AsQueryable<T>();
        }
        public long TotalItems { get; set; }
        public IQueryable<T> Items { get; set; }
    }
}

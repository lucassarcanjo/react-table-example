using System.Collections.Generic;

namespace Backend
{
    public class PaginatedResponse<T> where T : class
    {
        public int TotalCount { get; set; }

        public int FilteredCount { get; set; }

        public IEnumerable<T> Data { get; set; }

        public PaginatedResponse()
        {
            
        }

        public PaginatedResponse(int totalCount, int filteredCount, IEnumerable<T> data)
        {
        TotalCount = totalCount;
        FilteredCount = filteredCount;
        Data = data;
        }
    } 
}
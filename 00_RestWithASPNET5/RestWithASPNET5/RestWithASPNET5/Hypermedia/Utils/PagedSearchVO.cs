using RestWithASPNET5.Hypermedia.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5.Hypermedia.Utils
{
    public class PagedSearchVO<T> where T : ISupportsHyperMedia
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalResults { get; set; }
        public string SortFields { get; set; }
        public string SorteDirections { get; set; }
        public Dictionary<string,object> Filters { get; set; }
        public List<T> List { get; set; }

        public PagedSearchVO()
        {
        }

        public PagedSearchVO(int currentPage, int pageSize, string sortFields, string sorteDirections)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            SortFields = sortFields;
            SorteDirections = sorteDirections;
        }

        public PagedSearchVO(int currentPage, int pageSize, string sortFields, string sorteDirections, Dictionary<string, object> filters) : this(currentPage, pageSize, sortFields, sorteDirections)
        {
            Filters = filters;
        }

        public PagedSearchVO(int currentPage, string sortFields, string sorteDirections) : this(currentPage,10,sortFields,sorteDirections)
        {
            
        }

        public int GetCurrentPage()
        {
            return CurrentPage == 0 ? 2 : CurrentPage;
        }

        public int GetPageSize()
        {
            return PageSize == 0 ? 10 : PageSize;
        }
    }
}

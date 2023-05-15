namespace PustokTemplate.ViewModels
{
    public class PaginatedList<T>
    {
        public PaginatedList(List<T> items, int pageindex, int totalpage)
        {
            Items = items;
            PageIndex = pageindex;
            TotalPage = totalpage;  
        }
        public List<T> Items { get; set; }
        public int PageIndex { get; set; }
        public int TotalPage { get; set; }
        public bool HasNext => PageIndex < TotalPage;
        public bool HasPrevious => 1 < PageIndex;
        
        public static PaginatedList<T> Create(IQueryable<T> query, int page, int size)
        {
            int totalItem = (int)Math.Ceiling(query.Count() / (double)size);
            return new PaginatedList<T>(query.Skip((page - 1) * size).Take(size).ToList(), page, totalItem);
        }
    }
}

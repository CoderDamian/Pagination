namespace Persistence.Entities
{
    // T: any models that require pagination can use it.
    public class Page<T>
    {
        const int MaxPageSize = 500;
        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public IList<T> Items { get; set; }
        private int pageSize;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

        public Page()
        {
            Items = new List<T>();
        }
    }
}

namespace ShoppingCartApp.Repositories.Repos.UserRepos
{
    internal class PaginationFilter
    {
        private int pageNumber;
        private int pageSize;

        public PaginationFilter(int pageNumber, int pageSize)
        {
            this.pageNumber = pageNumber;
            this.pageSize = pageSize;
        }
    }
}
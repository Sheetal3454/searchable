namespace Searchable.Models
{
    public class Pager
    {
        public int TotalUsers {  get; private set; }

        public int CurrentPage {  get; private set; }
        
        public int PageSize {  get; private set; }

        public int TotalPages {  get; private set; }

        public int StartPage { get; private set; }

        public int EndPage { get; private set;}


        public Pager()
        {

        }

        public Pager (int totalUsers, int page, int pageSize = 10)
        {
            int totalPages = (int)Math.Ceiling((decimal)totalUsers / (decimal)pageSize);
            int currenetPage = page;

            int startPage = CurrentPage-5;
            int endPage = currenetPage + 4;


            if (startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;

            }

            if (endPage > totalPages)
            {
                endPage = totalPages;
                if(endPage> 10)
                {
                    startPage = endPage - 9;
                }
            }



            TotalUsers = totalUsers;
            CurrentPage = currenetPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;

        }
    }




}

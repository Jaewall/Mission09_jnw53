using System;

namespace Mission09_jnw53.Models.ViewModels
{
    public class PageInfo
    {
        //Figure out the total number of books, books per page, and the current page
        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }

        //Figure out how many pages we need
        public int TotalPages => (int) Math.Ceiling((double)TotalNumBooks / BooksPerPage);

    }
}

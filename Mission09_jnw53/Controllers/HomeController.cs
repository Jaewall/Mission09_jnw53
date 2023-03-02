using Microsoft.AspNetCore.Mvc;
using Mission09_jnw53.Models;
using Mission09_jnw53.Models.ViewModels;
using System.Linq;

namespace Mission09_jnw53.Controllers
{
    public class HomeController : Controller
    {
        //Bring in the repository
        private IBookstoreRepository repo;

        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;
            //Create the data to pass to the page
            var data = new BooksViewModel
            {
                //Sort the books by title and determine how many books go to each page
                Books = repo.Books
                .OrderBy(B => B.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                //Determine the page info to determine which books to display
                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum,
                }
            };

            
            return View(data);
        }
    }
}

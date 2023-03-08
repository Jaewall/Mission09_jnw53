using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission09_jnw53.Infrastructure;
using Mission09_jnw53.Models;
using System.Linq;

namespace Mission09_jnw53.Pages
{
    public class CartModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }
        
        public CartModel (IBookstoreRepository temp)
        {
            repo = temp;
        }
        public Basket basket { get; set; }

        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            basket.AddItem(b, 1);

            HttpContext.Session.SetJson("basket", basket);
            return RedirectToPage(new {ReturnUrl = returnUrl});
        }   

    }
}

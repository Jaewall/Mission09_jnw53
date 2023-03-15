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
        
        public CartModel (IBookstoreRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }
        public Basket basket { get; set; }

        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
           
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket.AddItem(b, 1);

            return RedirectToPage(new {ReturnUrl = returnUrl});
        }   

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book);
            return RedirectToPage( new{ ReturnUrl = returnUrl });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Mission09_jnw53.Models;
namespace Mission09_jnw53.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket basket;
        public CartSummaryViewComponent(Basket basketService)
        {
           basket = basketService;
        }
        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}

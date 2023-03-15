using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Mission09_jnw53.Models
{
    public class EFCheckoutRepository : ICheckoutRepository
    {
        private BookstoreContext context;
        public EFCheckoutRepository(BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Checkout> Checkout => context.Checkouts.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveCheckout(Checkout checkout)
        {
            context.AttachRange(checkout.Lines.Select(x => x.Book));

            if (checkout.CheckoutId == 0)
                {
                    context.Checkouts.Add(checkout);
                }

            context.SaveChanges();
        }
    }
}

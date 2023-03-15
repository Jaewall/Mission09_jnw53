using System.Linq;

namespace Mission09_jnw53.Models
{
    public interface ICheckoutRepository
    {
        IQueryable<Checkout> Checkout { get; }

        void SaveCheckout(Checkout checkout);
    }
}

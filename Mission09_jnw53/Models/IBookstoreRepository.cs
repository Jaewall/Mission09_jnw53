using System.Linq;

namespace Mission09_jnw53.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}

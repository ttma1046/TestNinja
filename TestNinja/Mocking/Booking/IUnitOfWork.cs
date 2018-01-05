using System.Linq;

namespace TestNinja.Mocking.Booking
{
    public interface IUnitOfWork
    {
        IQueryable<T> Query<T>();
    }
}
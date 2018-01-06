using System;
using System.Linq;

namespace TestNinja.Mocking.HouseKeeper
{
    public interface IHousekeeperService
    {
        IQueryable<Housekeeper> RetrieveHousekeepers();
    }
}
using System;
using System.Linq;

namespace TestNinja.Mocking.HouseKeeper
{
    public interface IHousekeeperService
    {
        void EmailFile(string emailAddress, string emailBody, string filename, string subject);

        IQueryable<Housekeeper> RetrieveHousekeepers();
    }
}
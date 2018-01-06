using System;
using System.Linq;

namespace TestNinja.Mocking.HouseKeeper
{
    public interface IHousekeeperService
    {
        string SaveStatement(int housekeeperOid, string housekeeperName, DateTime statementDate);
        
        void EmailFile(string emailAddress, string emailBody, string filename, string subject);

        IQueryable<Housekeeper> RetrieveHousekeepers();
    }
}
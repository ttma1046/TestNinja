using System;
using System.Linq;

namespace TestNinja.Mocking.HouseKeeper
{
    public interface IHousekeeperService
    {
        bool SendStatementEmails(DateTime statementDate);
    }
}
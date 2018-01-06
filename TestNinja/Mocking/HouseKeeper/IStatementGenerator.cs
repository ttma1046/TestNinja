using System;

namespace TestNinja.Mocking.HouseKeeper
{
    public interface IStatementGenerator
    {
        string SaveStatement(int housekeeperOid, string housekeeperName, DateTime statementDate);
    }
}
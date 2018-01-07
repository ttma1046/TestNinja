namespace TestNinja.Mocking.HouseKeeper
{
    public interface IMessageBox
    {
        void Show(string s, string housekeeperStatements, MessageBoxButtons ok);
    }
}
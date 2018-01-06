namespace TestNinja.Mocking.HouseKeeper
{
    public interface IEmailSender
    {
        void EmailFile(string emailAddress, string emailBody, string filename, string subject);
    }
}
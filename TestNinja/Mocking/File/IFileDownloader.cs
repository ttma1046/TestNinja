namespace TestNinja.Mocking.File
{
    public interface IFileDownloader
    {
        void DownloadFile(string url, string path);
    }
}
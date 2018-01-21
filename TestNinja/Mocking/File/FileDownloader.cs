using System.Net;

namespace TestNinja.Mocking.File
{
    public class FileDownloader : IFileDownloader
    {
        public void DownloadFile(string url, string path)
        {
            var client = new WebClient();

            client.DownloadFile(url, path);
        }
    }
}
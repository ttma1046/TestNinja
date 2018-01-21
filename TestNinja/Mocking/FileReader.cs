namespace TestNinja.Mocking
{
    public class FileReader : IFileReader
    {
        public string Read(string path)
        {
            return System.IO.File.ReadAllText(path);
        }
        
    }
}
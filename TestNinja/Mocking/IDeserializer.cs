namespace TestNinja.Mocking
{
    public interface IDeserializer
    {
        T DeserializeObject<T>(string input);
    }
}
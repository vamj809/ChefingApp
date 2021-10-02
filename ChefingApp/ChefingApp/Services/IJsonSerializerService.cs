namespace ChefingApp.Services
{
    public interface IJsonSerializerService
    {
        string Serialize(object payload);

        T Deserialize<T>(string payload);
    }
}

namespace MyApp.Services.API
{
    public interface IFileStorage
    {
        byte[] ReadAsBytes(string filename);

        string ReadAsString(string filename);
    }
}

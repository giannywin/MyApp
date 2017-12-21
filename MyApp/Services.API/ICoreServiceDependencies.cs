namespace MyApp.Services.API
{
    public interface ICoreServiceDependencies
    {
        IFileStorage FileStorage { get; set; }
    }
}

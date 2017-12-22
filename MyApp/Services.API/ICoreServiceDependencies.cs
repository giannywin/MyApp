namespace MyApp.Services.API
{
    public interface ICoreServiceDependencies
    {
        IHttpService HttpService { get; set; }

        IAppSettingsService AppSettingsService { get; set; }
    }
}

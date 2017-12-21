using MyApp.PageModels;
using Xamarin.Forms;
using MyApp.Models;
using MyApp.Services;
using MyApp.Services.API;
using FreshMvvm;
using System;
using System.Reflection;
using System.Linq;

namespace MyApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            RegisterDependencies();

            MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<LoginPageModel>());
        }

        protected override void OnStart()
        {
            var appSettingsService = FreshIOC.Container.Resolve<IAppSettingsService>();

            var settings = appSettingsService.GetSettings();

            Properties[MyAppConstants.AppSettings] = settings;
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected void RegisterDependencies() {
            RegisterServices();
        }

        protected void RegisterServices() {
            var types = typeof(CoreServiceDependencies).Assembly().DefinedTypes.ToList();

            var serviceTypes = types.Where(t => t.Namespace.StartsWith(typeof(CoreServiceDependencies).Namespace, StringComparison.OrdinalIgnoreCase) &&
                                           t.Name.Contains("Service") &&
                                           !t.IsInterface).ToList();

            var serviceInterfaceTypes = types.Where(t => t.Namespace.StartsWith(typeof(ICoreServiceDependencies).Namespace, StringComparison.OrdinalIgnoreCase) &&
                                                    t.Name.Contains("Service") &&
                                                    t.Name.StartsWith("I", StringComparison.OrdinalIgnoreCase) &&
                                                    t.IsInterface).ToList();

            var methods = typeof(FreshTinyIOCBuiltIn).GetRuntimeMethods().Where(t => t.Name == "Register").ToList();
            MethodInfo registerMethod = null;

            foreach(var method in methods) {
                var parameters = method.GetGenericArguments();
                if (parameters.Count() == 2 && parameters[0].Name == "RegisterType" && parameters[1].Name == "RegisterImplementation")
                    registerMethod = method;
            }

            foreach(var serviceInterfaceType in serviceInterfaceTypes) {
                var serviceType = serviceTypes.FirstOrDefault(t => serviceInterfaceType.IsAssignableFrom(t) &&
                                                                   t.Name == serviceInterfaceType.Name.Substring(1));

                if (serviceType != null && registerMethod != null) {
                    var genericMethod = registerMethod.MakeGenericMethod(new [] { serviceInterfaceType.AsType(), serviceType.AsType()});
                    genericMethod.Invoke(FreshIOC.Container, null);
                }
            }
        }
    }
}

﻿using MyApp.PageModels;
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

            var appSettingsService = FreshIOC.Container.Resolve<IAppSettingsService>();

            var settings = appSettingsService.GetSettings();

            Current.Properties[MyAppConstants.AppSettings] = settings;

            NavigationPage = new NavigationPage();

            MainPage = FreshPageModelResolver.ResolvePageModel<LoginPageModel>();
        }

        public static NavigationPage NavigationPage { get; set; }

        protected override void OnStart()
        {
            // Handle when your app starts
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

            var serviceTypes = types.Where(t => t.Namespace?.StartsWith(typeof(CoreServiceDependencies)?.Namespace, StringComparison.OrdinalIgnoreCase) == true &&
                                           t.Name.Contains("Service") &&
                                           !t.IsAbstract &&
                                           !t.IsInterface).ToList();

            var serviceInterfaceTypes = types.Where(t => t.Namespace?.StartsWith(typeof(ICoreServiceDependencies)?.Namespace, StringComparison.OrdinalIgnoreCase) == true &&
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

            FreshTinyIOCBuiltIn.Current.Register(typeof(IGenericService<>), typeof(GenericService<>));
        }
    }
}

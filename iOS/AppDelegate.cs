using Foundation;
using MyApp.Services.API;
using MyApp.iOS.Services;
using UIKit;

namespace MyApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            // Code for starting up the Xamarin Test Cloud Agent
#if DEBUG
			Xamarin.Calabash.Start();
#endif

            RegisterDependencies();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        private void RegisterDependencies()
        {
            FreshMvvm.FreshIOC.Container.Register<IFileStorage, FileStorage>();
        }
    }
}

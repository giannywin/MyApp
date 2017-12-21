using Android.App;
using Android.Content.PM;
using Android.OS;
using MyApp.Services.API;
using MyApp.Droid.Services;

namespace MyApp.Droid
{
    [Activity(Label = "MyApp.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            RegisterDependencies();

            LoadApplication(new App());
        }

        private void RegisterDependencies() {
            FreshMvvm.FreshIOC.Container.Register<IFileStorage, FileStorage>();
        }
    }
}

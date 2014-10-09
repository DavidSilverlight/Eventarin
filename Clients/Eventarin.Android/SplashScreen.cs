using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

/*
Thanks to
https://forums.xamarin.com/discussion/19362/xamarin-forms-splashscreen-in-android#latest
*/
namespace Eventarin.Android
{
    [Activity(Label = "ITPalooza", MainLauncher = true, NoHistory = true, Theme = "@style/Theme.Splash",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

          //ds  var intent = new Intent(this, typeof(MainActivity));
			var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
            Finish();
        }
    }
}


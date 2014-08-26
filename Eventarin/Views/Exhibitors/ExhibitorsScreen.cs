using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Webkit;

namespace ITPalooza.Android.Screens
{
    [Activity(Label = "Exhibitors", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ExhibitorsScreen : BaseScreen
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // set our layout to be the home screen
            this.SetContentView(Resource.Layout.ExhibitorsScreen);

            var web = FindViewById<WebView>(Resource.Id.ExhibitorImageView);
            web.LoadUrl("file:///android_asset/Exhibitors/index.html");
        }
    }
}
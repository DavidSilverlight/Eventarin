using Android.OS;
using Android.App;

namespace Eventarin.Android
{
	using System.Threading;

	[Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
	public class SplashActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			Thread.Sleep (2000);
			StartActivity(typeof(MainActivity));
		}


	


	}


}




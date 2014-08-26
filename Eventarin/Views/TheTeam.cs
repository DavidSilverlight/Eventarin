using System;
using Xamarin.Forms;

namespace Eventarin
{
	public class TheTeam : ContentPage
	{
		public TheTeam ()
		{
			NavigationPage.SetHasNavigationBar (this, true);
			Title = "The Mobile Team";

            // set our layout to be the home screen
         //   this.SetContentView(Resource.Layout.AboutXamScreen);

         //   var web = FindViewById<WebView>(Resource.Id.AboutWebView);
         //   web.LoadUrl("file:///android_asset/About/index.html");



			// embedded HTML page
			//			var source = new HtmlWebViewSource ();
			//			source.BaseUrl = "About.html";
			//			source.Html = "About.html";

			// a URL is easier
			var source = new UrlWebViewSource ();
			source.Url = "file:///android_asset/About/index.html";

			var web = new WebView {
				WidthRequest = 300,
				HeightRequest = 500
			};
			web.Source = source;

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = {
					web,
				}
			};
		}
	}
}


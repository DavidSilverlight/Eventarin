using System;
using Xamarin.Forms;

namespace ITPalooza2014
{
	public class AboutPage : ContentPage
	{
		public AboutPage ()
		{
			NavigationPage.SetHasNavigationBar (this, true);
			Title = "About ITPalooza";

			// embedded HTML page
//			var source = new HtmlWebViewSource ();
//			source.BaseUrl = "About.html";
//			source.Html = "About.html";

			// a URL is easier
			var source = new UrlWebViewSource ();
			source.Url = "http://ITPalooza.com";

			var web = new WebView {
				WidthRequest = 300,
				HeightRequest = 400
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


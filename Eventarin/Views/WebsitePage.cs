using System;
using Xamarin.Forms;

namespace Eventarin
{
	public class WebsitePage : ContentPage
	{
		public WebsitePage ()
		{
			NavigationPage.SetHasNavigationBar (this, true);
			Title = "About ITPalooza";
					
			// a URL is easier
			var source = new UrlWebViewSource ();
			source.Url = "http://ITPalooza.com";

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


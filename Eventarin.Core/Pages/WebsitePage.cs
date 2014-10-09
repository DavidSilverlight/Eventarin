using System;
using Eventarin.Core.Pages;
using Xamarin.Forms;

namespace Eventarin
{
    public class WebsiteCodePage : BaseContentPage
	{
		public WebsiteCodePage ()
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


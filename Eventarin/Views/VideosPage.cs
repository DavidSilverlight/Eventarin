using System;
using Xamarin.Forms;

namespace Eventarin
{
	public class VideosPage : ContentPage
	{
		public VideosPage ()
		{
			NavigationPage.SetHasNavigationBar (this, true);
			Title = "ITPalooza Videos";


			var label = new Label {
				Text="Keynote",
				YAlign = TextAlignment.Center,
				TextColor = Color.Gray,
				Font = Font.SystemFontOfSize(25),
			};

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = {
					label,
				}
			};
		}
	}
}


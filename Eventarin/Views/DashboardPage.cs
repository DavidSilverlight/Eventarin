using System;
using Xamarin.Forms;

namespace Eventarin
{
	public class DashboardPage : ContentPage
	{
		public DashboardPage ()
		{
			NavigationPage.SetHasNavigationBar (this, true);
			Title = "ITPalooza Dashboard";


			var label = new Label {
				Text="My IT Palooza",
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


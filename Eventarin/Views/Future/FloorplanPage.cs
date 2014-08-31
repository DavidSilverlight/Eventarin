using System;
using Xamarin.Forms;

namespace Eventarin
{
	public class FloorplanPage : ContentPage
	{
		public FloorplanPage ()
		{
			NavigationPage.SetHasNavigationBar (this, true);
			Title = "IT Palooza Floor Plan";


			var label = new Label {
				Text="IT Palooza Floor Map",
				YAlign = TextAlignment.Center,
				TextColor = Color.Gray,
				Font = Font.SystemFontOfSize(25),
			};

			var image = new Image(){WidthRequest = 400, HeightRequest=500} ;
    		image.Source = ImageSource.FromFile ("FloorPlanITPalooza.png");


			var layout = new StackLayout {
				BackgroundColor = Color.White,// App.HeaderTint,
				Padding = new Thickness(20, 0, 0, 0),
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = {label, image}


			};
			Content = layout;


		}
	}
}


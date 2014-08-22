using System;
using Xamarin.Forms;

namespace ITPalooza2014
{
	public class FloorplanPage : ContentPage
	{
		public FloorplanPage ()
		{
			NavigationPage.SetHasNavigationBar (this, true);
			Title = "Room Plan";

			var imageSource = FileImageSource.FromFile ("FloorPlan_Hilton_both");
			var image = new Image { 
				Source = imageSource
				//X=0, Y=20, Width=320, Height=460
			};

			Content = new AbsoluteLayout {
				Children = {
				 image
				}
			};
		}
	}
}


﻿using System;
using Xamarin.Forms;

namespace Eventarin
{
	public class LocationMapPage : ContentPage
	{
		public LocationMapPage ()
		{
			NavigationPage.SetHasNavigationBar (this, true);
			Title = "ITPalooza Map";


			var label = new Label {
				Text="IT Palooza Location",
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

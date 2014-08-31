﻿using System;
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
				Text = "My Sessions",
				YAlign = TextAlignment.Center,
				TextColor = Color.Gray,
				Font = Font.SystemFontOfSize (25),
			};

			ListView listView = new ListView {
				RowHeight = 40
			};

			listView.ItemsSource = new Session [] { new Session { Title = "test", Location = "somewhere" } };
			listView.ItemTemplate = new DataTemplate (typeof(SessionCell));

			listView.ItemSelected += (sender, e) => {
				var session = e.SelectedItem;
				var sessionPage = new SessionPage ();
				//	todoPage.BindingContext = todoItem;
				Navigation.PushAsync (sessionPage);
			};

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = { listView }
			};
		

			var labelFriends = new Label {
				Text = "My Friends",
				YAlign = TextAlignment.Center,
				TextColor = Color.Gray,
				Font = Font.SystemFontOfSize (25),
			};


			var labelVendors = new Label {
				Text = "Favorite Vendors",
				YAlign = TextAlignment.Center,
				TextColor = Color.Gray,
				Font = Font.SystemFontOfSize (25),
			};


			Content = new StackLayout {
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = {
					label,labelFriends, labelVendors
				}
			};
		}
	}
}

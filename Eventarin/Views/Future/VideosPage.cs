﻿using System;
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



			// Set our view from the "main" layout resource
		//	SetContentView (Resource.Layout.Main);

		//	var videoView = FindViewById<VideoView> (Resource.Id.SampleVideoView);

		//	var uri = Android.Net.Uri.Parse ("http://ia600507.us.archive.org/25/items/Cartoontheater1930sAnd1950s1/PigsInAPolka1943.mp4");

		//	videoView.SetVideoURI (uri);
	//		videoView.Start ();  



			Content = new StackLayout {
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = {
					label,
				}
			};
		}
	}
}

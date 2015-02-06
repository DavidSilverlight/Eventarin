using System;
using Xamarin.Forms;
using Eventarin.Core.ViewModels;

namespace Eventarin.Core.Pages
{
	public class BaseContentPage : ContentPage
	{
		protected ActivityIndicator ActivityIndicator
		{
			get;
			set;
		}

		protected bool IncludeActivityIndicator
		{
			get;
			set;
		}

		public BaseContentPage()
		{
			IncludeActivityIndicator = true;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			var layout = this.Content as Layout<View>;

			if (layout != null && ActivityIndicator == null)
			{
				ActivityIndicator = new ActivityIndicator();
				if (IncludeActivityIndicator)
				{
					ActivityIndicator.IsRunning = true;
					ActivityIndicator.HorizontalOptions = LayoutOptions.CenterAndExpand;
					ActivityIndicator.VerticalOptions = LayoutOptions.CenterAndExpand;
					ActivityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, new Binding("IsBusy"));
					ActivityIndicator.SetBinding(ActivityIndicator.IsVisibleProperty, new Binding("IsBusy"));
					ActivityIndicator.BackgroundColor = Color.White;
					layout.Children.Add(ActivityIndicator);
				}

			}
		}
	}
}


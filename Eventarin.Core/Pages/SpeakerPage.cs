using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Eventarin.Core.ViewModels;
using System.Threading.Tasks;
using System.Diagnostics;
using ImageCircle.Forms.Plugin.Abstractions;

namespace Eventarin.Core.Pages
{	
	public partial class SpeakerPage : BaseContentPage
	{	
		SpeakersViewModel viewModel;

		public SpeakerPage ()
		{
			InitializeComponent ();
			viewModel = App.SimpleIoC.Resolve<SpeakersViewModel> ();
			BindingContext = viewModel;

			if (viewModel.CurrentSpeaker.HeadshotUrl.Length > 0) 
			{
				try 
				{

					var photo = new CircleImage 
					{
						BorderColor = Color.White,
						BorderThickness = 3,
						HeightRequest = 75,
						WidthRequest = 75,
						Aspect = Aspect.AspectFill,
						HorizontalOptions = LayoutOptions.Center,
						Source = UriImageSource.FromUri (new Uri (viewModel.CurrentSpeaker.HeadshotUrl))
						//Source = UriImageSource.FromFile("TeamMirMaheed")
						//Source = UriImageSource.FromUri (new Uri ("http://upload.wikimedia.org/wikipedia/commons/5/55/Tamarin_portrait.JPG"))

					};
					stackCircles.Children.Clear ();
					stackCircles.Children.Add (photo);
				} 
				catch (Exception exc) 
				{

				}
			}
		}
	}
}




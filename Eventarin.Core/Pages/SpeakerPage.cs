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
			viewModel = App.SimpleIoC.Resolve<SpeakersViewModel>();
			BindingContext = viewModel;

		//	this.Content.SetValue
		//	stackCircles.Children.Add (HeadshotDisplayUrl);


			var photo = new CircleImage {
				BorderColor = Color.White,
				BorderThickness = 3,
				HeightRequest = 75,
				WidthRequest = 75,
				Aspect = Aspect.AspectFill,
				HorizontalOptions = LayoutOptions.Center,
				Source = UriImageSource.FromUri ( new Uri(viewModel.CurrentSpeaker.HeadshotUrl))
				//Source = UriImageSource.FromFile("TeamMirMaheed")
					//Source = UriImageSource.FromUri (new Uri ("http://upload.wikimedia.org/wikipedia/commons/5/55/Tamarin_portrait.JPG"))

			};
			stackCircles.Children.Clear ();
			stackCircles.Children.Add (photo);





//			this.ToolbarItems.Add(new ToolbarItem {
//                Text = "Refresh",
//				Icon = "reload.png",
//				Command = viewModel.RefreshCommand
//			});

			this.ToolbarItems.Add(new ToolbarItem {
				Text = "",

				//Icon = "hamburger_menu_icon.png",
				Command = viewModel.RefreshCommand

			});


		}

		public ImageSource HeadshotDisplayUrl {
			get {

				var photo = new CircleImage {
					BorderColor = Color.White,
					BorderThickness = 3,
					HeightRequest = 75,
					WidthRequest = 75,
					Aspect = Aspect.AspectFill,
					HorizontalOptions = LayoutOptions.Center,
					Source = UriImageSource.FromUri (new Uri (viewModel.CurrentSpeaker.HeadshotUrl))
						//Source = UriImageSource.FromFile(this.HeadshotUrl)
						//Source = UriImageSource.FromUri (new Uri ("http://upload.wikimedia.org/wikipedia/commons/5/55/Tamarin_portrait.JPG"))

				};

				return photo.Source;
			}
		}


//		protected override void OnParentSet()
//		{
//			base.OnParentSet();
//			viewModel.RefreshCommand.Execute(null);
//		}
	}
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageCircle;
using Xamarin.Forms;
using ImageCircle.Forms.Plugin.Abstractions;
using Eventarin.Core.ViewModels;
using System.ServiceModel.Channels;
using Eventarin.Core.Models;
using Eventarin.Core.Data;

namespace Eventarin.Core.ContentViews
{
	public partial class SessionImageContentView
    {

//		SpeakersViewModel viewModel;
		public SessionImageContentView()
		{
			InitializeComponent ();
	//		viewModel = App.SimpleIoC.Resolve<SpeakersViewModel>();
	//		BindingContext = viewModel;
	//		SetSpeakerCircles ();
		}



		protected override void OnBindingContextChanged()
		{
			try 
			{
		//	base.OnBindingContextChanged();
			SetSpeakerCircles ();
			}
			catch (Exception exc) {
				//Do nothing!
			}

		}



		private void SetSpeakerCircles()
		{

			var session = (Session)BindingContext;
			var speakerID = session.Speaker_Id;

			if (speakerID != null) {
				var speaker = EventRepository.GetSpeaker (int.Parse (speakerID));
				if (speaker != null) {

					var photo = new CircleImage {
						BorderColor = Color.White,
						BorderThickness = 4,
						HeightRequest = 100,
						WidthRequest = 100,
						Aspect = Aspect.AspectFill,
						HorizontalOptions = LayoutOptions.Center,
						Source = UriImageSource.FromUri (new Uri (speaker.HeadshotUrl))
					};
					stackCircles.Children.Add (photo);
				}
			}
		}
    }
}

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

namespace Eventarin.Core.ContentViews
{
	public partial class SpeakerCellContentView2
    {

		public SpeakerCellContentView2()
		{
			InitializeComponent ();
		}



		protected override void OnBindingContextChanged()
		{
			try 
			{
			base.OnBindingContextChanged();
			SetSpeakerCircles ();
			}
			catch (Exception exc) {
				//Do nothing!
			}

		}



		private void SetSpeakerCircles()
		{

			var speaker = (Speaker)BindingContext;

			var photo = new CircleImage {
				BorderColor = Color.White,
				BorderThickness = 4,
				HeightRequest = 50,
				WidthRequest = 50,
				Aspect = Aspect.AspectFill,
				HorizontalOptions = LayoutOptions.Center,
				Source = UriImageSource.FromUri (new Uri (speaker.HeadshotUrl))
			};
			stackCircles.Children.Add (photo);
		}

    }
}

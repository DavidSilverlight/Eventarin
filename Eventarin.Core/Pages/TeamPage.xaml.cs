using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Eventarin.Core.ViewModels;
using ImageCircle.Forms.Plugin.Abstractions;

namespace Eventarin.Core.Pages
{
    public partial class TeamPage : BaseContentPage
	{	
		public TeamPage ()
		{
			InitializeComponent ();
            BindingContext = App.SimpleIoC.Resolve<TeamViewModel>();
			SetSpeakerCircles ();
		}

		private void SetSpeakerCircles()
		{
			SetSpeakerCircle (stackDavidSilverlight, "TeamDavidSilverlight");
			SetSpeakerCircle (stackJonasStawski, "TeamJonasStawski");
			SetSpeakerCircle (stackMirMaheed, "TeamMirMaheed");
			SetSpeakerCircle (stackCarlosMacias, "TeamCarlosMacias");
			SetSpeakerCircle (stackZacharyWeiner, "TeamZacharyWeiner");
			SetSpeakerCircle (stackPaulPleasant, "NoPerson");
			SetSpeakerCircle (stackAdamHeller, "TeamAdamHeller");

		}

		private void SetSpeakerCircle(StackLayout speakerStack, string speakerName)
		{

			var photo = new CircleImage {
				BorderColor = Color.Black,
				BorderThickness = 4,
				HeightRequest = 60,
				WidthRequest = 60,
				Aspect = Aspect.AspectFill,
				HorizontalOptions = LayoutOptions.Center,
				Source = UriImageSource.FromFile(speakerName)
			};
			speakerStack.Children.Add (photo);
		}
	}
}


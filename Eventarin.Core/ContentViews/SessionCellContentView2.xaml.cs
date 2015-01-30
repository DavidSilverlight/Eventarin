using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageCircle;
using Xamarin.Forms;
using ImageCircle.Forms.Plugin.Abstractions;
using Eventarin.Core.ViewModels;

namespace Eventarin.Core.ContentViews
{
    public partial class SessionCellContentView2
    {
		public SessionCellContentView2()
		{
			InitializeComponent ();

			var photo = new CircleImage {
				BorderColor = Color.White,
				BorderThickness = 3,
				HeightRequest = 75,
				WidthRequest = 75,
				Aspect = Aspect.AspectFill,
				HorizontalOptions = LayoutOptions.Center,
				Source = UriImageSource.FromFile("NoAvatarProfile")
				//Source = UriImageSource.FromUri (new Uri ("http://upload.wikimedia.org/wikipedia/commons/5/55/Tamarin_portrait.JPG"))
			
			};

			stackCircles.Children.Add (photo);

		}
    }
}

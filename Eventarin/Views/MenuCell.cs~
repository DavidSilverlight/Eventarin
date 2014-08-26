using System;
using Xamarin.Forms;

namespace Eventarin
{
	public class MenuCell : ViewCell
	{
		public string Text { 
			get { return label.Text; }
			set{ label.Text = value;} 
		}

		public string Icon { get; set;}


		Label label;

		public MenuPage Host { get; set; }

		public MenuCell (string icon)
		{
			label = new Label {
				YAlign = TextAlignment.Center,
				TextColor = Color.Gray,
				Font = Font.SystemFontOfSize(25),
			};

	


			var image = new Image () ;
		//	image.Width = 35;
		//	image.Height = 35;
			if (icon != null) {
				image.Source = ImageSource.FromFile (icon + ".png");
			}

			var layout = new StackLayout {
				BackgroundColor = Color.White,// App.HeaderTint,
				Padding = new Thickness(20, 0, 0, 0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = {image, label}


			};
			View = layout;
		}

		protected override void OnTapped ()
		{
			base.OnTapped ();

			Host.Selected (label.Text);
		}
	}
}


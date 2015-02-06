using System;
using Xamarin.Forms;
using ImageCircle;
using System.IO;

namespace Eventarin.Core.Models
{
	public class Session
	{

		public Session()
		{
		}
		[SQLite.Net.Attributes.PrimaryKey]
        public int Id
        {
            get;
            set;
        }
		public string Title
		{
			get;
			set;
		}

        public string Abstract
        {
            get;
            set;
        }


		public string Summary
		{
			get;
			set;
		}

		public string Location
		{
			get;
			set;
		}

        public string Track
        {
            get;
            set;
        }


		public string Sponsor
		{
			get;
			set;
		}


		public string Speakers
		{
			get;
			set;
		}

		public string Speaker_Id
		{
			get;
			set;
		}




        public DateTime Begins
        {
            get;
            set;
        }

        public DateTime Ends
        {
            get;
            set;
        }

    

		public bool IsFavorite
		{
			get;
			set;
		}

//		public string FavoriteMessage
//		{
//			get
//			{
//				if (IsFavorite)
//				{
//					return "Saved as a Favorite";
//				}
//				else
//				{
//					return "Add to Favorites";
//				}
//			}
//		}

//		public ImageSource SessionSubheader {
//			get {
//				var fileName = "subheader_1";
//
//
//
//				Random r = new Random();
//				int rInt = r.Next(1, 6); //for ints
//				int range = 6;
//				double rDouble = r.NextDouble()* range; //for doubles
//
//				Int32 rFileID = Convert.ToInt32 (rDouble);
//
//				if (rFileID < 1 || rFileID > 6) {
//					rFileID = 1;
//				}
//
//
//			 	fileName = "subheader_" + rFileID.ToString ();
//
//				return ImageSource.FromFile (fileName);
//			}
//		}
//        
//		public ImageSource FavoriteImage
//		{
//			get
//			{
//				if (IsFavorite)
//				{
//					//return ImageSource.FromFile("Favorite");
//					return ImageSource.FromFile ("add_to itinerary42x50");
//				}
//				else
//				{
//					//return ImageSource.FromFile("NotFavorite");
//					return ImageSource.FromFile ("add_to itinerary42x50");
//				}
//			}
//		}
//

//		public ImageSource FavoriteCircle
//		{
//			get {
//
//				int photoSize = Device.OnPlatform (50, 50, 80);
//				//var a = new 
//				var photo = new ImageCircle.Forms.Plugin.Abstractions.CircleImage {
//					Source = FavoriteImage,
//					WidthRequest = photoSize,
//					HeightRequest = photoSize,
//					Aspect = Aspect.AspectFill,
//					HorizontalOptions = LayoutOptions.Center
//				};
//			//	photo.SetBinding (Image.SourceProperty, s => s.Image);
//
//				//	photo.
//				return photo.Source;
//			}
//			
//		}

//		protected override bool DrawChild(Canvas canvas, global::Android.Views.View child, long drawingTime)
//		{
//			  try
//			  {
//				var Width = 50;
//				var Height = 50;
//
//				    var radius = Math.Min(Width, Height) / 2;
//				    var strokeWidth = 10;
//				    radius -= strokeWidth / 2;
//				    //Create path to clip
//				    var path = new Path();
//				    path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);
//				    canvas.Save();
//				    canvas.ClipPath(path);
//				    var result = base.DrawChild(canvas, child, drawingTime);
//				    canvas.Restore();
//				    // Create path for circle border
//				    path = new Path();
//				    path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);
//				    var paint = new Paint();
//				    paint.AntiAlias = true;
//				    paint.StrokeWidth = 5;
//				    paint.SetStyle(Paint.Style.Stroke);
//				    paint.Color = global::Android.Graphics.Color.White;
//				    canvas.DrawPath(path, paint);
//				    //Properly dispose
//				    paint.Dispose();
//				    path.Dispose();
//				    return result;
//				  }
//			  catch (Exception ex)
//			  {
//				    Debug.WriteLine("Unable to create circle image: " + ex);
//				  }
//			  return base.DrawChild(canvas, child, drawingTime);
//
//		}

//        public ImageSource HeadshotDisplayUrl
//		{
//			get
//			{
//					return ImageSource.FromFile("NoAvatar.png");
//			}
//		}
//
	}
}


using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ImageCircle.Forms.Plugin.Abstractions;

namespace Eventarin.Core.Models
{
    /* Example Json
{"id":0,"name":"Chris Hardy","twitterHandle":"chrisntr","bio":"Chris Hardy, a Microsoft ASPInsider, is an .NET consultant focusing on MonoTouch and Mono for Android development.\n\nEver since MonoTouch was in beta, Chris has been developing and evangelising MonoTouch and Mono for Android and was one of the first users to get a MonoTouch application on to the App Store. Speaking at conferences around the world on the subject, Chris has been a key part of the community and extended this by contributing to MonoTouch and Mono for Android books.","headshotUrl":"/images/speakers/chris.jpg"}
     */
    public class Speaker
    {
        public Speaker()
        {
            //	Sessions = new List<Session>();
        }

 //       [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string TwitterHandle { get; set; }
        public string Bio { get; set; }
        public string BioSummary { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string HeadshotUrl { get; set; }





		public string BioExcerpt
		{
			get
			{
				var bio = "Bio: " + Bio + "";
				if (bio.Length > 250) {
					bio = bio.Substring (0, 250) + "...";
				}
				return bio;
			}
		}

		public ImageSource SpeakerSubheader {
			get {
				var fileName = "subheader_1";



				Random r = new Random();
				int rInt = r.Next(1, 6); //for ints
				int range = 6;
				double rDouble = r.NextDouble()* range; //for doubles

				Int32 rFileID = Convert.ToInt32 (rDouble);

				if (rFileID < 1 || rFileID > 6) {
					rFileID = 1;
				}


				fileName = "subheader_" + rFileID.ToString ();

				return ImageSource.FromFile (fileName);
			}
		}


        //public string HeadshotDisplayUrl
        //{
        //    get
        //    {
        //        return HeadshotUrl;
        //    }
        //}

//        public ImageSource HeadshotDisplayUrlOrig
//        {
//            get
//            {
//            //    if (IsFavorite)
//            //    {
//                    //return ImageSource.FromFile(this.HeadshotUrl);
//				System.Uri headshotUrl = new System.Uri (this.HeadshotUrl);
//				return ImageSource.FromUri (headshotUrl);
//            //    }
//            ///    else
//            //    {
//            //        return ImageSource.FromFile("star_grey45.png");
//            //    }
//            }
//        }


//		public ImageSource HeadshotDisplayUrl {
//			get {
//
//				var photo = new CircleImage {
//					BorderColor = Color.White,
//					BorderThickness = 3,
//					HeightRequest = 75,
//					WidthRequest = 75,
//					Aspect = Aspect.AspectFill,
//					HorizontalOptions = LayoutOptions.Center,
//					Source = UriImageSource.FromUri (new Uri (this.HeadshotUrl))
//					//Source = UriImageSource.FromFile(this.HeadshotUrl)
//					//Source = UriImageSource.FromUri (new Uri ("http://upload.wikimedia.org/wikipedia/commons/5/55/Tamarin_portrait.JPG"))
//
//				};
//
//				return photo.Source;
//			}
//		}
//
//
//		public ImageSource CurrentSpeakerImage {
//			get {
//
//				var photo = new CircleImage {
//					BorderColor = Color.White,
//					BorderThickness = 3,
//					HeightRequest = 75,
//					WidthRequest = 75,
//					Aspect = Aspect.AspectFill,
//					HorizontalOptions = LayoutOptions.Center,
//					Source = UriImageSource.FromFile ("TeamMirMaheed")
//						//Source = UriImageSource.FromUri (new Uri ("http://upload.wikimedia.org/wikipedia/commons/5/55/Tamarin_portrait.JPG"))
//
//				};
//				return photo.Source;
//				//	photo.Source;
//				//	stackCircles.Children.Clear ();
//				//	stackCircles.Children.Add (photo);
//
//				//	photo.SetBinding(Image.SourceProperty, s => s.Image);
//			}
//		}
//
//
  /*
        [Ignore]
        public List<Session> Sessions { get; set; }

        [Ignore]
        public bool HasTwitter
        {
            get
            {
                return !String.IsNullOrWhiteSpace(TwitterHandle) && (Device.OS == TargetPlatform.iOS);
            }
        }
   */
    }
}


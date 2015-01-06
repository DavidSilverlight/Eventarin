using System;
using System.Collections.Generic;
using Xamarin.Forms;

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
				return Bio.Substring (0, 450) + "...";
			}
		}

        //public string HeadshotDisplayUrl
        //{
        //    get
        //    {
        //        return HeadshotUrl;
        //    }
        //}

        public ImageSource HeadshotDisplayUrl
        {
            get
            {
            //    if (IsFavorite)
            //    {
                    //return ImageSource.FromFile(this.HeadshotUrl);
				System.Uri headshotUrl = new System.Uri (this.HeadshotUrl);
				return ImageSource.FromUri (headshotUrl);
            //    }
            ///    else
            //    {
            //        return ImageSource.FromFile("star_grey45.png");
            //    }
            }
        }

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


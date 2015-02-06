using System;
using Xamarin.Forms;
using ImageCircle;
using System.IO;

namespace Eventarin.Core.Models
{
	public class Track
	{

		public Track()
		{
		}
		[SQLite.Net.Attributes.PrimaryKey]
        public int Id
        {
            get;
            set;
        }
		public string Room
		{
			get;
			set;
		}

        public string Name
        {
            get;
            set;
        }


		public string Description
		{
			get;
			set;
		}

	}
}


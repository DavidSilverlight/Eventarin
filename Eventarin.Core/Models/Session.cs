using System;
using Xamarin.Forms;

namespace Eventarin.Core.Models
{
	public class Session
	{
		public Session()
		{
		}

		public string Title
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

		public bool IsFavorite
		{
			get;
			set;
		}

		public ImageSource FavoriteImage
		{
			get
			{
				if (IsFavorite)
				{
					return ImageSource.FromFile("star_gold45.png");
				}
				else
				{
					return ImageSource.FromFile("star_grey45.png");
				}
			}
		}

	}
}


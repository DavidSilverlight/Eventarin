﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Eventarin.Core.ViewModels;

namespace Eventarin.Core.Pages
{	
	public partial class WebsitePage : BaseContentPage
	{	
		public WebsitePage ()
		{
			InitializeComponent ();
			BindingContext = App.SimpleIoC.Resolve<WebsiteViewModel>();
		}
	}
}


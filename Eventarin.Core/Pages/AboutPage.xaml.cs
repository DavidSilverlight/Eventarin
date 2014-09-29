using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Eventarin.Core.ViewModels;

namespace Eventarin.Core.Pages
{	
	public partial class AboutPage : BaseContentPage
	{	
		public AboutPage ()
		{
			InitializeComponent ();
			BindingContext = App.SimpleIoC.Resolve<AboutViewModel>();
		}
	}
}


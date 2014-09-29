using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Eventarin.Core.ViewModels;

namespace Eventarin.Core.Pages
{	
	public partial class SpeakersPage : BaseContentPage
	{	
		public SpeakersPage ()
		{
			InitializeComponent ();
			BindingContext = App.SimpleIoC.Resolve<SpeakersViewModel>();
		}
	}
}


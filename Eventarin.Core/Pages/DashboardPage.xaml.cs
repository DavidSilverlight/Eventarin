using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Eventarin.Core.Pages
{	
	public partial class DashboardPage : BaseContentPage
	{	
		public DashboardPage ()
		{
			InitializeComponent ();
			BindingContext = App.SimpleIoC.Resolve<DashboardViewModel>();
		}
	}
}


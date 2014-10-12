using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Eventarin.Core.ViewModels;

namespace Eventarin.Core.Pages
{
    public partial class TeamPage : BaseContentPage
	{	
		public TeamPage ()
		{
			InitializeComponent ();
            BindingContext = App.SimpleIoC.Resolve<TeamViewModel>();
		}
	}
}


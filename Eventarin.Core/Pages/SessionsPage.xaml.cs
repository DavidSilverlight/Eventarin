using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Eventarin.Core.ViewModels;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Eventarin.Core.Pages
{	
	public partial class SessionsPage : BaseContentPage
	{	
		SessionsViewModel viewModel;
		public SessionsPage ()
		{
			InitializeComponent ();
			viewModel = App.SimpleIoC.Resolve<SessionsViewModel>();
			BindingContext = viewModel;
			viewModel.RefreshCommand.Execute(null);
		}
	}
}


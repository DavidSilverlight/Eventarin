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


			this.ToolbarItems.Add(new ToolbarItem {
                Name = "Refresh",
                Icon = "nav_refresh.png",
				Command = viewModel.RefreshCommand
			});
		}

		protected override void OnParentSet()
		{
			base.OnParentSet();
			viewModel.RefreshCommand.Execute(null);
		}
	}
}


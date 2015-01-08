using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Eventarin.Core.ViewModels;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Eventarin.Core.Pages
{	
	public partial class SpeakerPage : BaseContentPage
	{	
		SpeakersViewModel viewModel;
		public SpeakerPage ()
		{
			InitializeComponent ();
			viewModel = App.SimpleIoC.Resolve<SpeakersViewModel>();
			BindingContext = viewModel;


			this.ToolbarItems.Add(new ToolbarItem {
                Text = "Refresh",
				Icon = "reload.png",
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


using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Eventarin.Core.ViewModels;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Eventarin.Core.Pages
{	
	public partial class SpeakersPage : BaseContentPage
	{	
		SpeakersViewModel viewModel;

		public SpeakersPage ()
		{
			InitializeComponent ();
			viewModel = App.SimpleIoC.Resolve<SpeakersViewModel>();
			BindingContext = viewModel;


			ListSpeakers.ItemSelected += (sender, e) => {
				viewModel.CurrentSpeaker = (Eventarin.Core.Models.Speaker)e.SelectedItem;
				var speakerID = 0;
				{
					if (viewModel.CurrentSpeaker != null) {
						speakerID = viewModel.CurrentSpeaker.Id;
						viewModel.SpeakerItemClicked.Execute (speakerID);
					}
				}

			};





		}





		protected override void OnParentSet()
		{
			base.OnParentSet();
	//		viewModel.RefreshCommand.Execute(null);
		}


	}
}


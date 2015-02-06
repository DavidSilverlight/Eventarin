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


			stackSessions.HeightRequest = 250 * viewModel.Sessions.Count;

			//DS 010715 CodeSmell - Use Commanding. Research why the EventarinCell Command is always null
			ListSessions.ItemSelected += (sender, e) => {
				viewModel.CurrentSession = (Eventarin.Core.Models.Session)e.SelectedItem;
				var sessionID = 0;
				{
					if (viewModel.CurrentSession != null) {
						sessionID = viewModel.CurrentSession.Id;
						viewModel.SessionItemClicked.Execute (sessionID);
					}
				}

			};

			  
		}


		protected override void OnParentSet()
		{
			base.OnParentSet();
			viewModel.RefreshCommand.Execute(null);
		}
	}
}


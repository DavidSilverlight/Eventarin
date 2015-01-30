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

			//DS 010715 CodeSmell - Use Commanding
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




//			this.ToolbarItems.Add(new ToolbarItem {
//                Text = "Refresh",
//				Icon = "reload.png",
//				Command = viewModel.RefreshCommand
//			});
			//this.ToolbarItems.Clear ();
//			var hamburgerItem = new ToolbarItem ();
//			hamburgerItem.Order = ToolbarItemOrder.Primary;
//			hamburgerItem.Priority = 0;
//			hamburgerItem.Text = "Back to sessions";
//		

			//(TextCell = "Sessions", "hamburger_menu_icon.png", Action.Combine, ToolbarItemOrder.Primary, 0);
		//	this.ToolbarItems.Add (hamburgerItem);
//			this.ToolbarItems.Add(new ToolbarItem {
//				Text = "",
//			
//				Icon = "hamburger_menu_icon.png",
//
//				Command = viewModel.RefreshCommand
//
//			});
			//

			this.BackgroundColor = Color.White;    
		}


		protected override void OnParentSet()
		{
			base.OnParentSet();
			viewModel.RefreshCommand.Execute(null);
		}
	}
}


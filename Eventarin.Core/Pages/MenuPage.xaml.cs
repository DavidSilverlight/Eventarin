using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Eventarin.Core.ViewModels;

namespace Eventarin.Core.Pages
{	
	public partial class MenuPage : BaseContentPage
	{	
		public MenuPage () : base()
		{
			InitializeComponent ();
			BindingContext = App.SimpleIoC.Resolve<MenuViewModel>();
			IncludeActivityIndicator = false;
			this.ToolbarItems.Clear ();
		//	NavigationPage.SetTitleIcon(.SetBackButtonTitle (page, "test");
			this.ToolbarItems.Clear ();
		//		this.Icon = "hamburger_menu_icon";


		}


		protected override void OnAppearing()
		{
			var settings = new ToolbarItem
			{
				Icon = "hamburger_menu_icon",
				Name = "Settings"

				//Command = new Command(this.ShowSettingsPage),
			};
		
			this.ToolbarItems.Clear ();
		//	this.ToolbarItems.Add(settings);
		//	this.Icon = "hamburger_menu_icon";
			this.UpdateChildrenLayout ();
		}

		protected override void OnDisappearing()
		{
			this.ToolbarItems.Clear();
		}
	}
}


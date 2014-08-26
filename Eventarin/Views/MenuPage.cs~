using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Eventarin
{
	/// <summary>
	/// Required for PlatformRenderer
	/// </summary>
	public class MenuTableView : TableView 
	{
	}

	public class MenuPage : ContentPage
	{
		MasterDetailPage master;

		TableView tableView;

		public MenuPage (MasterDetailPage m)
		{
			master = m;

			Title = "ITPalooza 2014";

		//	Icon = "@drawable/slideout.png";

			var section = new TableSection () {
				new MenuCell("tab_sessions_unselected") {Text = "Sessions", Host = this, Icon="tab_sessions_unselected"},
				new MenuCell("tab_speakers_unselected") {Text = "Speakers", Host = this, Icon="tab_speakers_unselected"},
				new MenuCell("tab_schedule_unselected") {Text = "Favorites", Host = this, Icon="tab_schedule_unselected"},
				new MenuCell("tab_maps_unselected") {Text = "Room Plan", Host = this},
				new MenuCell("tab_maps_unselected") {Text = "Map", Host = this},
				new MenuCell("tab_maps_unselected") {Text = "The Team", Host = this},
				new MenuCell("tab_maps_unselected") {Text = "Dashboard", Host = this},
				new MenuCell("tab_maps_unselected") {Text = "Website", Host = this},
				new MenuCell("tab_maps_unselected") {Text = "Videos", Host = this, Icon=""},
			//	new MenuCell("tab_maps_unselected") {Text = "About", Host = this},

			//	new MenuCell("tab_maps_unselected") {Text = "iBeacon", Host = this, Icon=""},
			};

			var root = new TableRoot () {section} ;
		
			tableView = new MenuTableView ()
			{ 
				Root = root,
//				HeaderTemplate = new DataTemplate (typeof(MenuHeader)),
				Intent = TableIntent.Menu,
			};


			Content = new StackLayout {
				BackgroundColor = Color.White,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {tableView}
			};
		}

		NavigationPage sessions, speakers, favorites;

		public void Selected (string item) {

			switch (item) {
			case "Website":
				master.Detail = new NavigationPage (new WebsitePage ()) { BackgroundColor = Color.Red };
				break;

			case "Dashboard":
				master.Detail = new NavigationPage (new DashboardPage ()) { BackgroundColor = Color.Red };
				break;

			case "Sessions":
				if (sessions == null)
					sessions = new NavigationPage (new SessionsPage ()) { BackgroundColor = App.NavTint };
				master.Detail = sessions;
				break;
			case "Speakers":
				if (speakers == null) {
					speakers = new NavigationPage (new SpeakersPage ()) {  BackgroundColor = App.NavTint };
					//TODO: finish WrapLayout demo
					//speakers = new NavigationPage (new SpeakersPageWrap ()) { Tint = App.NavTint };
				}
				master.Detail = speakers;
				break;
			case "Favorites":
				if (favorites == null)
					favorites = new NavigationPage (new FavoritesPage ()) { BackgroundColor = App.NavTint };
				master.Detail = favorites;
				break;
			case "Room Plan":
				master.Detail = new NavigationPage(new FloorplanPage()) {BackgroundColor = App.NavTint};
				break;

			case "The Team":
				master.Detail = new NavigationPage(new TheTeam()) {BackgroundColor = App.NavTint};
				break;

			case "Videos":
				master.Detail = new NavigationPage(new VideosPage()) {BackgroundColor = App.NavTint};
				break;



			case "Map":
				master.Detail = new NavigationPage(new LocationMapPage()) {BackgroundColor = App.NavTint};
				break;




			};

			master.IsPresented = false;  // close the slide-out
		}
	}
}
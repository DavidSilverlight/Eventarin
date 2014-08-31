using System;
using Xamarin.Forms;

namespace Eventarin
{
	public class App
	{

		public static Page GetMainPage ()
		{
			var md = new MasterDetailPage ();

			md.Master = new MenuPage (md){ BackgroundColor = Color.Gray };
			md.Detail = new NavigationPage(new DashboardPage ());

			return md;
		}

		static SQLite.Net.SQLiteConnection conn;
		static EventDatabase database;
		public static void SetDatabaseConnection (SQLite.Net.SQLiteConnection connection)
		{
			conn = connection;
			database = new EventDatabase (conn);
		}
		public static EventDatabase Database {
			get { return database; }
		}


		public static Color NavTint {
			get {
				return Color.FromHex ("3498DB"); // Xamarin Blue
			}
		}
		public static Color HeaderTint {
			get {
				return Color.FromHex ("2C3E50"); // Xamarin DarkBlue
			}
		}
	}
}


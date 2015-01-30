using System;
using Xamarin.Forms;
using Eventarin.Core.ViewModels;
using Eventarin.Core.Pages;
using System.Reflection;
using System.Linq;
using Eventarin.Core.Services;
using System.Net.Http;
using Eventarin.Core.Data;

namespace Eventarin.Core
{
	public static class App
	{
		static readonly INavigationService navigationService;

		static App()
		{
			RegisterAllViewModels();
			RegisterAllServices();
			navigationService = SimpleIoC.Resolve<INavigationService>();
		}

		private static void RegisterAllViewModels()
		{
			Assembly currentAssembly = typeof(App).GetTypeInfo().Assembly;

			var viewModelTypes = currentAssembly.ExportedTypes.Where(t => t.Name.EndsWith("ViewModel"));
			foreach (var type in viewModelTypes)
			{
				if (!type.GetTypeInfo().IsAbstract)
				{
					SimpleIoC.RegisterSingleton(type);
				}
			}
		}

		private static void RegisterAllServices()
		{
			SimpleIoC.RegisterSingleton<IPageCachingService, PageCachingService>();
			SimpleIoC.RegisterSingleton<INavigationService, NavigationService>();
			var client = new HttpClient();
			SimpleIoC.RegisterInstance<IWebService>(new WebService(client));
		}

		public static Page GetMainPage()
		{
			return navigationService.GetMainPage();
		}



		private static volatile SimpleIoC simpleIoC;
		private static object syncRoot = new Object();

		public static SimpleIoC SimpleIoC
		{
			get 
			{
				if (simpleIoC == null) 
				{
					lock (syncRoot) 
					{
						if (simpleIoC == null) 
							simpleIoC = new SimpleIoC();
					}
				}

				return simpleIoC;
			}
		}

        #region "Database"

        static SQLite.Net.SQLiteConnection conn;
        static EventDatabase database;
        public static void SetDatabaseConnection(SQLite.Net.SQLiteConnection connection)
        {
            conn = connection;
            database = new EventDatabase(conn);
        }




        public static EventDatabase Database
        {
            get { return database; }
        }

        #endregion

    }
}


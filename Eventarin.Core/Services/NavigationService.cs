using System;
using Xamarin.Forms;
using Eventarin.Core.Pages;
using System.Threading.Tasks;

namespace Eventarin.Core.Services
{
	public class NavigationService : INavigationService
	{
		readonly IPageCachingService _pageCachingService;
		MasterDetailPage md = null;
		public NavigationService(IPageCachingService pageCachingService)
		{
			_pageCachingService = pageCachingService;
		}

		public MasterDetailPage GetMainPage()
		{
			if (md == null)
			{
				md = new MasterDetailPage();
			}
 		//	md.Master = _pageCachingService.GetPage<MenuPage>();
 		//	md.Detail = _pageCachingService.GetPage<SessionsPage>();
		//	md.Detail = _pageCachingService.GetPage<TeamPage> ();

		md.Master = new MenuPage ();
			md.Detail = new TeamPage ();
			return md;
		}

		public void NavigateModal<t>() where t : BaseContentPage
		{
			t page = _pageCachingService.GetPage<t>();
		//	page = new NavigationPage(t);

			if (page == null) {

				md.Detail.Navigation.PushModalAsync (new SpeakerPage ());
			}
			else
			{
				md.Detail.Navigation.PushModalAsync (page);

			}
		}

		public void Navigate<t>() where t : BaseContentPage
		{
			t page = _pageCachingService.GetPage<t>();
			// TODO: This works for now because the parents are always NavigationPage, 
			// but that not might be the case in the future.
			// Figure out the right way to remove the parent.

			NavigationPage np;

			if (page == null) {

				np = new  NavigationPage(page);
			}
		
			np = page.Parent as NavigationPage;
			if (np == null)
			{
				np = new  NavigationPage(page);
				np.BarBackgroundColor = Color.White;
				np.BarTextColor = Color.Black;

			}

		


		///	md.Detail = page;

		//	md.Detail.Navigation.PushAsync(page);
			md.Detail = np;
			md.BackgroundColor = Color.White;
			md.IsPresented = false;  // close the slide-out
		}
	}
}


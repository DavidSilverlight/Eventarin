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
			md.Master = _pageCachingService.GetPage<MenuPage>();
			md.Detail = _pageCachingService.GetPage<DashboardPage>();

			return md;
		}

		public void Navigate<t>() where t : BaseContentPage
		{
			t page = _pageCachingService.GetPage<t>();
			// TODO: This works for now because the parents are always NavigationPage, 
			// but that not might be the case in the future.
			// Figure out the right way to remove the parent.
			var np = page.Parent as NavigationPage;
			if (np == null)
			{
				np = new NavigationPage(page);
			}

			md.Detail = np;
			md.IsPresented = false;  // close the slide-out
		}
	}
}


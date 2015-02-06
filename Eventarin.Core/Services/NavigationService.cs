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
			md.Detail = new SessionsPage ();
			return md;
		}







		public void NavigateModal<t>() where t : BaseContentPage
		{
			t page = _pageCachingService.GetPage<t>();
		//	page = new NavigationPage(t);

			if (page != null) {
				md.Detail.Navigation.PushModalAsync (page);
			}

			md.BackgroundColor = Color.White;
			md.IsPresented = false;  // close the slide-out
			md.Title = "abc";


//			var modalPage = new ContentPage ();
//			await Navigation.PushModalAsync (modalPage);
//			Debug.WriteLine ("The modal page is now on screen");
//			var poppedPage = await Navigation.PopModalAsync ();
//			Debug.WriteLine ("The modal page is dismissed");
//			Debug.WriteLine (Object.ReferenceEquals (modalPage, poppedPage)); //prints "true"
		}


		public void NavigateModalToSpeaker<t>() where t : BaseContentPage
		{
			t page = _pageCachingService.GetPage<t>();
			//	page = new NavigationPage(t);


				md.Detail.Navigation.PushModalAsync (new SpeakerPage ());
		}

		public void NavigateFromSpeaker<t>() where t : BaseContentPage
		{
			t page = _pageCachingService.GetPage<t>();
			//	page = new NavigationPage(t);


			md.Detail.Navigation.PopModalAsync ();
		}

		public void NavigateFromSession<t>() where t : BaseContentPage
		{
			t page = _pageCachingService.GetPage<t>();
			//	page = new NavigationPage(t);


			md.Detail.Navigation.PopModalAsync ();
		}



		public void Navigate<t>() where t : BaseContentPage
		{


			try 
			{

			//t page = _pageCachingService.GetPage<t>();
			// TODO: This works for now because the parents are always NavigationPage, 
			// but that not might be the case in the future.
			// Figure out the right way to remove the parent.

		//	NavigationPage np = new  NavigationPage<t>();

			Page page = _pageCachingService.GetPage<t>();

			//page.Title = "hello";

//			t page;//= new Page<t> ();
//
//			if (page == null) {
//
//				np = new  NavigationPage(page);
//			}
//		
//			var np = page.Parent as NavigationPage;
//			if (np == null)
//			{
//				np = new  NavigationPage(page);
//				np.BarBackgroundColor = Color.White;
//				np.BarTextColor = Color.Black;
//
//			}

		
			if (page != null) {

				md.Detail = page;
			}

		//	md.Detail.Navigation.PushAsync(new NavigationPage(page));
			md.Detail = page;
			md.BackgroundColor = Color.White;
			md.IsPresented = false;  // close the slide-out
			md.Title = "test 3";


			}
			catch ( Exception exc ) 
			{
				//Toast.MakeText(this, exc.Message, ToastLength.Long).Show();
			}
		}




		public void NavigateToSpeakers<t>() where t : BaseContentPage
		{
			md.Detail = new SpeakersPage();
			md.BackgroundColor = Color.White;
			md.IsPresented = false;  // close the slide-out
			md.Detail.Title = "page";
		}


		public void NavigateToItinerary<t>() where t : BaseContentPage
		{
			md.Detail = new ItineraryPage();
			md.BackgroundColor = Color.White;
			md.IsPresented = false;  // close the slide-out
			md.Detail.Title = "page";
		}








	}
}


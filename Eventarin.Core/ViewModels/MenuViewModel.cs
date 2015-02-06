using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Eventarin.Core.Services;
using Eventarin.Core.Pages;

namespace Eventarin.Core.ViewModels
{
	public class MenuViewModel : BaseViewModel
	{
		readonly INavigationService _navigationService;
		public MenuViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
			PageTitle = " ";
		}

		public ICommand DashboardClicked
		{
			get
			{
				return new Command(() =>
				{
					_navigationService.NavigateToItinerary<ItineraryPage>();
				});
			}
		}

		public ICommand SpeakersClicked
		{
			get
			{
				return new Command(() =>
				{
				//		NavigationPage.Navigation.PushAsync(new SpeakersPage());
						_navigationService.NavigateToSpeakers<SpeakersPage>();
				});
			}
		}

		public ICommand SessionsClicked
		{
			get
			{
				return new Command(() =>
				{
					
					_navigationService.Navigate<SessionsPage>();
				});
			}
		}

		public ICommand WebsiteClicked
		{
			get
			{
				return new Command(() =>
				{
					_navigationService.Navigate<WebsitePage>();
            //        _navigationService.Navigate<WebsiteCodePage>();
				});
			}
		}

		public ICommand AboutClicked
		{
			get
			{
				return new Command(() =>
				{
					_navigationService.Navigate<AboutPage>();
				});
			}
		}

        public ICommand TeamClicked
        {
            get
            {
                return new Command(() =>
                {
                    _navigationService.Navigate<TeamPage>();
                });
            }
        }
	}

	public class Menu
	{
		public string Text
		{
			get;
			set;
		}
	}
}


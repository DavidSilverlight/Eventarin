using System;
using Eventarin.Core.Services;
using System.Collections.ObjectModel;
using Eventarin.Core.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.Generic;
using Eventarin.Core.Data;
using System.Linq;
using Eventarin.Core.Pages;
using System.Net;
using System.Net.Http;




namespace Eventarin.Core.ViewModels
{
	public class SessionsViewModel : BaseViewModel
	{
		readonly IWebService _webService;
		readonly INavigationService _navigationService;

		public SessionsViewModel(IWebService webService, INavigationService navigationService)
		{
			_navigationService = navigationService;
			_webService = webService;
			PageTitle = "";
		}

        private string _categoryFilter = "mobile";
        public string CategoryFilter { 
            get {
                return _categoryFilter;
            } 
      
        }

        public ObservableCollection<Session> Sessions
		{
			get
			{
                return EventRepository.GetSessions();
			}
			set
			{

                    EventRepository.SaveSessions(value);
					RaisePropertyChanged(() => Sessions);
			}
		}


		public ObservableCollection<Session> MySessions
		{
			get
			{
				return EventRepository.GetMySessions();
			}
			set
			{

				//EventRepository.SaveSessions(value);
				RaisePropertyChanged(() => Sessions);
			}
		}


		private Session _currentSession = null;
		public Session CurrentSession
		{
			get
			{
				if (_currentSession == null)
				{
					_currentSession = EventRepository.GetSessions().FirstOrDefault();
				}
				return _currentSession;
			}
			set
			{
				_currentSession = value;
				RaisePropertyChanged(() => CurrentSession);
			}
		}



		public ICommand RefreshCommand
		{
			get 
			{
            //    return EventRepository.GetSessions;
                 return new Command (async () => Sessions = EventRepository.GetSessions()); 
		       // return new Command (async () => await GetSessions()); 
			}

		}



		public ICommand SessionItemClicked
		{
			get
			{
				return new Command(() =>
					{

					//	_navigationService.Navigate<SessionPage>();
						_navigationService.NavigateModal<SessionPage>();
					});
			}
		}

		public ICommand FavoriteStarClicked
		{
			get
			{
				return new Command(() =>
					{
						CurrentSession.IsFavorite = !CurrentSession.IsFavorite;
						EventRepository.SaveSession(CurrentSession);


						RaisePropertyChanged(() => CurrentSession);
					});

			}
		}


		private async Task GetSessions()
		{
			if (IsBusy)
			{
				return;
			}

			IsBusy = true;

			var result = await _webService.GetSessions();
            //ObservableCollection<Session> sessionCollection = new ObservableCollection<Session>(result);
            //Todo : Merge result  back into Database Sessions
            
            var fakeResult = EventRepository.GetSessions();
            var refreshedSessions = EventRepository.MergeSessions(fakeResult);
            
            RaisePropertyChanged(() => Sessions);
			
			IsBusy = false;

		}






	}
}


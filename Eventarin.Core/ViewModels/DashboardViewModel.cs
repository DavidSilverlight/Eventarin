using System;
using Eventarin.Core.Services;
using System.Collections.ObjectModel;
using Eventarin.Core.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.Generic;
using Eventarin.Core.Data;
using Eventarin.Core.Pages;

namespace Eventarin.Core.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {

        readonly IWebService _webService;
        readonly INavigationService _navigationService;

        public DashboardViewModel(IWebService webService, INavigationService navigationService)
        {
            _webService = webService;
            _navigationService = navigationService;
            PageTitle = "Dashboard";
        }


        public ICommand SessionItemClicked
        {
            get
            {
                return new Command(() =>
                {
                    _navigationService.Navigate<SessionPage>();
                });
            }
        }


        public ObservableCollection<Session> Sessions
        {
            get
            {
                return EventRepository.GetMySessions();
            }
            set
            {

                EventRepository.SaveSessions(value);
                RaisePropertyChanged(() => Sessions);
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () => Sessions = EventRepository.GetMySessions());
                //  return new Command(async () => await GetSessions());
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

        public bool HasFavorites()
        {
            var sessions = Sessions;
            bool hasFavorites = false;

            if (sessions != null)
            {
                hasFavorites = (sessions.Count > 0);
            }
            return hasFavorites;
        }

        public bool NoFavorites()
        {
            return !HasFavorites();
        }
    }
}


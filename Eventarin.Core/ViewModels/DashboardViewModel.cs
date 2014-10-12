﻿using System;
using Eventarin.Core.Services;
using System.Collections.ObjectModel;
using Eventarin.Core.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.Generic;
using Eventarin.Core.Data;

namespace Eventarin.Core.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        readonly IWebService _webService;
        public DashboardViewModel(IWebService webService)
        {
            _webService = webService;
            PageTitle = "Dashboard";
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


    }
}

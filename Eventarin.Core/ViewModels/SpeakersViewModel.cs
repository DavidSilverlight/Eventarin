using System;
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
    public class SpeakersViewModel : BaseViewModel
    {
        readonly IWebService _webService;
        public SpeakersViewModel(IWebService webService)
        {
            _webService = webService;
            PageTitle = "Speakers";
            GetSpeakers();
        }


        public ObservableCollection<Speaker> Speakers
        {
            get
            {
                return EventRepository.GetSpeakers();
            }
            set
            {
              EventRepository.SaveSpeakers(value);
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () => await GetSpeakers());
            }

        }

        private async Task GetSpeakers()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;
            //var result = await _webService.GetSpeakers();
            //if (result.Success)
            //{
            //    Speakers = new ObservableCollection<Speaker>(result.Data);
            //}
         //   Speakers = App.Database.GetSpeakers();
            IsBusy = false;

        }


    }
}


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


namespace Eventarin.Core.ViewModels
{
    public class SpeakersViewModel : BaseViewModel
    {
        readonly IWebService _webService;
		readonly INavigationService _navigationService;

		public SpeakersViewModel(IWebService webService, INavigationService navigationService)
        {
            _webService = webService;
			_navigationService = navigationService;
            PageTitle = " ";
           // GetSpeakers();  //according to the compiler, we should use async wait
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


		public ICommand SpeakerItemClicked
		{
			get
			{
				return new Command(() =>
					{
						//DS I would like to punch the NavigateModel in the face.

						//_navigationService.Navigate<SpeakerPage>();
						_navigationService.NavigateModal<SpeakerPage>();

						//_navigationService.NavigateModalToSpeaker<SpeakerPage>(new NavigationPage());
					});
			}
		}


		public ICommand CloseSpeakerClicked
		{
			get
			{
				return new Command(() =>
					{
						_navigationService.NavigateFromSpeaker<SpeakerPage>();
					//	RaisePropertyChanged(() => CurrentSession);
					});

			}
		}


		private Speaker _currentSpeaker = null;
		public Speaker CurrentSpeaker
		{
			get
			{
				if (_currentSpeaker == null)
				{
					_currentSpeaker = EventRepository.GetSpeakers().FirstOrDefault();
				}
				return _currentSpeaker;
			}
			set
			{
				_currentSpeaker = value;
				RaisePropertyChanged(() => CurrentSpeaker);
			}
		}

		public ImageSource SpeakerSubheader {
			get {
				var fileName = "subheader_1";



				Random r = new Random();
				int rInt = r.Next(1, 6); //for ints
				int range = 6;
				double rDouble = r.NextDouble()* range; //for doubles

				Int32 rFileID = Convert.ToInt32 (rDouble);

				if (rFileID < 1 || rFileID > 6) {
					rFileID = 1;
				}


				fileName = "subheader_" + rFileID.ToString ();

				return ImageSource.FromFile (fileName);
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


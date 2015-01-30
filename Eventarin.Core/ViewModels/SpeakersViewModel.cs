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
using ImageCircle.Forms.Plugin.Abstractions;

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
            GetSpeakers();  //according to the compiler, we should use async wait
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

						//_navigationService.Navigate<SpeakerPage>();
						_navigationService.NavigateModal<SpeakerPage>();
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

		public ImageSource CurrentSpeakerImage {
			get {

				var photo = new CircleImage {
					BorderColor = Color.White,
					BorderThickness = 3,
					HeightRequest = 75,
					WidthRequest = 75,
					Aspect = Aspect.AspectFill,
					HorizontalOptions = LayoutOptions.Center,
					Source = UriImageSource.FromFile ("TeamMirMaheed")
					//Source = UriImageSource.FromUri (new Uri ("http://upload.wikimedia.org/wikipedia/commons/5/55/Tamarin_portrait.JPG"))

				};
				return photo.Source;
			//	photo.Source;
			//	stackCircles.Children.Clear ();
			//	stackCircles.Children.Add (photo);

				//	photo.SetBinding(Image.SourceProperty, s => s.Image);
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


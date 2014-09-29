using System;
using Eventarin.Core.Services;
using System.Collections.ObjectModel;
using Eventarin.Core.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Eventarin.Core.ViewModels
{
	public class SessionsViewModel : BaseViewModel
	{
		readonly IWebService _webService;
		public SessionsViewModel(IWebService webService)
		{
			_webService = webService;
			PageTitle = "Sessions";
		}

		private ObservableCollection<Session> sessions;
		public ObservableCollection<Session> Sessions
		{
			get
			{
				return sessions;
			}
			set
			{
				if (sessions != value)
				{
					sessions = value;
					RaisePropertyChanged(() => Sessions);
				}
			}
		}

		private bool isBusy;
		public bool IsBusy
		{
			get
			{
				return isBusy;
			}
			set
			{
				if (isBusy != value)
				{
					isBusy = value;
					RaisePropertyChanged(() => IsBusy);
				}
			}
		}
			
		public ICommand RefreshCommand
		{
			get 
			{ 
				return new Command (async () => await GetSessions()); 
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
			if (result.Success)
			{
				Sessions = new ObservableCollection<Session>(result.Data);
			}
			IsBusy = false;

		}


	}
}


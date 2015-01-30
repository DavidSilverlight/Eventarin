using System;
using Eventarin.Core.Pages;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Eventarin.Core.Services
{
	public interface INavigationService
	{
		MasterDetailPage GetMainPage();
		void Navigate<t>() where t : BaseContentPage;
		void NavigateModal<t> () where t : BaseContentPage;

	}



}


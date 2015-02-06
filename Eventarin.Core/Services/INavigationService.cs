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
		void NavigateToSpeakers<t>() where t : BaseContentPage;
		void NavigateFromSpeaker<t>() where t : BaseContentPage;
		void NavigateFromSession<t>() where t : BaseContentPage;
		void NavigateModalToSpeaker<t> () where t: BaseContentPage;
		void NavigateToItinerary<t> () where t: BaseContentPage;
		void NavigateModal<t> () where t : BaseContentPage;

	}



}


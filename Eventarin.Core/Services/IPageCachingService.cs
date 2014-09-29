using System;
using Xamarin.Forms;

namespace Eventarin.Core.Services
{
	public interface IPageCachingService
	{
		t GetPage<t>() where t : Page;
	}
}


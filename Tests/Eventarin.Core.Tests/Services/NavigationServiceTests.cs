using System;
using NUnit.Framework;
using Moq;
using Eventarin.Core.Services;
using Should;
using Xamarin.Forms;
using Eventarin.Core.Pages;

namespace Eventarin.Core.Tests.Services
{
	[TestFixture]
	public class NavigationServiceTests
	{
		Mock<IPageCachingService> _pageCachingService;
		NavigationService service;

		[SetUp]
		public void Init()
		{
			_pageCachingService = new Mock<IPageCachingService>();
			service = new NavigationService(_pageCachingService.Object);
		}

		[Test]
		public void GetMainPage_Should_Return_MasterDetailPage_With_Right_Detail_And_Master()
		{
			// Arrange
			_pageCachingService.Setup(x => x.GetPage<MenuPage>()).Returns(new MenuPage());
			_pageCachingService.Setup(x => x.GetPage<SplashPage>()).Returns(new SplashPage());

			// Act
			var mainPage = service.GetMainPage();

			// Assert
			mainPage.ShouldBeType(typeof(MasterDetailPage));
			mainPage.Master.ShouldBeType(typeof(MenuPage));
			mainPage.Detail.ShouldBeType(typeof(SplashPage));
		}

		[Test]
		public void Navigate_Should_Change_The_Detail_To_The_NavigatedTo_Page()
		{
			// Arrange
			var sessionsPage = new SessionsPage();
			_pageCachingService.Setup(x => x.GetPage<MenuPage>()).Returns(new MenuPage());
			_pageCachingService.Setup(x => x.GetPage<SplashPage>()).Returns(new SplashPage());
			_pageCachingService.Setup(x => x.GetPage<SessionsPage>()).Returns(sessionsPage);
			var mainPage = service.GetMainPage();

			// Act
			service.Navigate<SessionsPage>();

			// Assert
			mainPage.Detail.ShouldBeType(typeof(NavigationPage));
			((NavigationPage)mainPage.Detail).CurrentPage.ShouldEqual(sessionsPage);
		}

		[Test]
		public void Navigate_Should_Try_To_Get_Page_From_Cache()
		{
			// Arrange
			var sessionsPage = new SessionsPage();
			_pageCachingService.Setup(x => x.GetPage<MenuPage>()).Returns(new MenuPage());
			_pageCachingService.Setup(x => x.GetPage<SplashPage>()).Returns(new SplashPage());
			_pageCachingService.Setup(x => x.GetPage<SessionsPage>()).Returns(sessionsPage);
			service.GetMainPage();

			// Act
			service.Navigate<SessionsPage>();

			// Assert
			_pageCachingService.Verify(x => x.GetPage<SessionsPage>(), Times.Once);
		}

		[Test]
		public void Navigate_Should_Still_Use_Previous_Navigation_Page_When()
		{
			// Arrange
			var sessionsPage = new SessionsPage();
			_pageCachingService.Setup(x => x.GetPage<MenuPage>()).Returns(new MenuPage());
			_pageCachingService.Setup(x => x.GetPage<SplashPage>()).Returns(new SplashPage());
			_pageCachingService.Setup(x => x.GetPage<SessionsPage>()).Returns(sessionsPage);

			service.GetMainPage();
			service.Navigate<SessionsPage>();

			// Act
			service.Navigate<SessionsPage>();

			// Assert
			_pageCachingService.Verify(x => x.GetPage<SessionsPage>(), Times.Exactly(2));
		}
	}
}


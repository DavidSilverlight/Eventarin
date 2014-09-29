using System;
using NUnit.Framework;
using Moq;
using Eventarin.Core.Services;
using Should;
using Xamarin.Forms;
using Eventarin.Core.Pages;
using System.Collections.Generic;

namespace Eventarin.Core.Tests.Services
{
	class PageCachingServiceMocked : PageCachingService
	{
		public Mock<IDictionary<Type, Page>> RegisteredPagesMocked;
		public PageCachingServiceMocked()
		{
			RegisteredPagesMocked = new Mock<IDictionary<Type, Page>>();
			RegisteredPages = RegisteredPagesMocked.Object;
		}
	}

	[TestFixture]
	public class PageCachingServiceTests
	{
		PageCachingServiceMocked service;

		[SetUp]
		public void Init()
		{
			service = new PageCachingServiceMocked();
		}

		[Test]
		public void GetPage_Should_Add_New_Page_To_Cache_When_It_Is_Not_Cached()
		{
			// Arrange
			var type = typeof(MenuPage);
			service.RegisteredPagesMocked.Setup(x => x.ContainsKey(type)).Returns(false);

			// Act
			service.GetPage<MenuPage>();

			// Assert
			service.RegisteredPagesMocked.Verify(x => x.ContainsKey(type), Times.Once);
			service.RegisteredPagesMocked.Verify(x => x.Add(type, It.IsAny<MenuPage>()), Times.Once);
		}

		[Test]
		public void GetPage_Should_Retrieve_Page_From_Cache_When_It_Is_Cached()
		{
			// Arrange
			var type = typeof(MenuPage);
			var page = new MenuPage();
			service.RegisteredPagesMocked.Setup(x => x.ContainsKey(type)).Returns(true);
			service.RegisteredPagesMocked.SetupGet(x => x[type]).Returns(page);

			// Act
			var p = service.GetPage<MenuPage>();

			// Assert
			service.RegisteredPagesMocked.Verify(x => x.Add(type, It.IsAny<MenuPage>()), Times.Never);
			service.RegisteredPagesMocked.Verify(x => x[type], Times.Once);
			p.ShouldEqual(page);
		}

	}
}


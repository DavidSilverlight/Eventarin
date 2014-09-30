using System;
using NUnit.Framework;
using Moq;
using Eventarin.Core.Services;
using Should;
using Xamarin.Forms;
using Eventarin.Core.Pages;
using Eventarin.Core.ViewModels;

namespace Eventarin.Core.Tests.ViewModels
{
	[TestFixture]
	public class MenuViewModelTests
	{
		Mock<INavigationService> _navigationService;
		MenuViewModel viewModel;

		[SetUp]
		public void Init()
		{
			_navigationService = new Mock<INavigationService>();
			viewModel = new MenuViewModel(_navigationService.Object);
		}

		[Test]
		public void MenuViewModel_Should_Inherit_From_BaseViewModel()
		{
			// Arrange

			// Act

			// Assert
			viewModel.ShouldImplement(typeof(BaseViewModel));
		}
			
		[Test]
		public void Speakerslicked_Should_Navigate_To_SpeakersPage()
		{
			// Arrange

			// Act
			viewModel.SpeakersClicked.Execute(null);

			// Assert
			_navigationService.Verify(x => x.Navigate<SpeakersPage>(), Times.Once);
		}

		[Test]
		public void SessionsClicked_Should_Navigate_To_SessionsPage()
		{
			// Arrange

			// Act
			viewModel.SessionsClicked.Execute(null);

			// Assert
			_navigationService.Verify(x => x.Navigate<SessionsPage>(), Times.Once);
		}

		[Test]
		public void DashboardClicked_Should_Navigate_To_DashboardPage()
		{
			// Arrange

			// Act
			viewModel.DashboardClicked.Execute(null);

			// Assert
			_navigationService.Verify(x => x.Navigate<DashboardPage>(), Times.Once);
		}

		[Test]
		public void WebsiteClicked_Should_Navigate_To_WebsitePage()
		{
			// Arrange

			// Act
			viewModel.WebsiteClicked.Execute(null);

			// Assert
			_navigationService.Verify(x => x.Navigate<WebsitePage>(), Times.Once);
		}

		[Test]
		public void AboutClicked_Should_Navigate_To_AboutPage()
		{
			// Arrange

			// Act
			viewModel.AboutClicked.Execute(null);

			// Assert
			_navigationService.Verify(x => x.Navigate<AboutPage>(), Times.Once);
		}

		[Test]
		public void PageTitle_Should_Be_Eventarin()
		{
			// Arrange
			var title = "Eventarin";
			// Act

			// Assert
			viewModel.PageTitle.ShouldEqual(title);
		}
	}
}


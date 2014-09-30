using System;
using NUnit.Framework;
using Moq;
using Should;
using Eventarin.Core.Services;
using System.Net.Http;
using System.Threading.Tasks;
using Eventarin.Core.Models;
using Newtonsoft.Json;
using System.Linq;

namespace Eventarin.Core.Tests.Services
{
	[TestFixture]
	public class WebServiceTests
	{
		WebService service;
		FakeHttpMessageHandler handler;

		[SetUp]
		public void Init()
		{
			handler = new FakeHttpMessageHandler();
			var client = new HttpClient(handler);
			service = new WebService(client);
		}

		#region GetSessions

		[Test]
		public async Task GetSessions_Should_Return_Sessions()
		{
			// Arrange
			var response = new HttpResponseMessage();
			response.StatusCode = System.Net.HttpStatusCode.OK;
			var sessions = new Session[] {
				new Session { Location = "location 1", Summary = "Summary 1", Title = "Title 1" },
				new Session { Location = "location 2", Summary = "Summary 2", Title = "Title 2" }
			};

			string sessionsJSON = JsonConvert.SerializeObject(sessions.AsEnumerable());
			response.Content = new StringContent(sessionsJSON);
			handler.Response = response;

			// Act
			var result = await service.GetSessions();

			// Assert
			result.Success.ShouldBeTrue();
			result.Reason.ShouldBeNull();
			result.Data.Count().ShouldEqual(sessions.Length);
			result.Data.ElementAt(0).Location.ShouldEqual(sessions[0].Location);
			result.Data.ElementAt(0).Summary.ShouldEqual(sessions[0].Summary);
			result.Data.ElementAt(0).Title.ShouldEqual(sessions[0].Title);

			result.Data.ElementAt(1).Location.ShouldEqual(sessions[1].Location);
			result.Data.ElementAt(1).Summary.ShouldEqual(sessions[1].Summary);
			result.Data.ElementAt(1).Title.ShouldEqual(sessions[1].Title);
		}

		[Test]
		public async Task GetSessions_Should_Fail_With_500()
		{
			// Arrange
			var response = new HttpResponseMessage();
			response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
			var ex = new Exception("An internal server error occurred");
			string exJson = JsonConvert.SerializeObject(ex);
			response.Content = new StringContent(exJson);
			handler.Response = response;

			// Act
			var result = await service.GetSessions();

			// Assert
			result.Success.ShouldBeFalse();
			result.Reason.ShouldEqual("An unexpected server error occurred");
			result.Data.ShouldBeNull();
		}

		[Test]
		public async Task GetSessions_Should_Fail_Gracefully()
		{
			// Arrange
			handler.Action = () =>
			{
				throw new Exception();
			};

			// Act
			var result = await service.GetSessions();

			// Assert
			result.Success.ShouldBeFalse();
			result.Reason.ShouldEqual("An unexpected error occurred");
			result.Data.ShouldBeNull();
		}
		#endregion GetSessions
	}
}


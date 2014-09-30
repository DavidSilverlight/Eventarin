using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Eventarin.Core.Tests.Services
{
	public class FakeHttpMessageHandler : HttpMessageHandler
	{
		public HttpResponseMessage Response { get; set; }
		public Action Action { get; set; }
		public FakeHttpMessageHandler()
		{

		}

		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if (Action != null)
			{
				Action.Invoke();
			}
			var tcs = new TaskCompletionSource<HttpResponseMessage>();

			tcs.SetResult(Response);

			return tcs.Task;
		}
	}
}


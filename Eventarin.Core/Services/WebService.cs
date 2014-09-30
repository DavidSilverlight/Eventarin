using System;
using System.Collections.Generic;
using Eventarin.Core.Models;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;

namespace Eventarin.Core.Services
{
	public class WebService : IWebService
	{
		readonly string baseUrl = "http://jsonblob.com/api/jsonBlob";
		protected HttpClient Client { get; private set; }

		public WebService(HttpClient client)
		{
			Client = client;
			Client.BaseAddress = new Uri(baseUrl);
		}
			
		public async Task<ServiceResult<IEnumerable<Session>>> GetSessions()
		{
			var result = new ServiceResult<IEnumerable<Session>>();
			try
			{
				var response = await Client.GetAsync("54282ef8e4b0fe3e7d739528");
				string responseContent = await response.Content.ReadAsStringAsync();
				if (response.StatusCode == HttpStatusCode.OK)
				{
					result.Success = true;
					result.Data = JsonConvert.DeserializeObject<IEnumerable<Session>>(responseContent);
				}
				if (response.StatusCode == HttpStatusCode.InternalServerError)
				{
					result.Success = false;
					result.Reason = "An unexpected server error occurred";
				}
			}
			catch
			{
				result.Success = false;
				result.Reason = "An unexpected error occurred";
			}
			return result;
		}
	}
}


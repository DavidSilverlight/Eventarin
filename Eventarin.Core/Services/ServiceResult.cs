using System;

namespace Eventarin.Core.Services
{
	public class ServiceResult<t>
	{
		public bool Success { get; set; }
		public string Reason { get; set; }
		public t Data { get; set; }
	}
}


using System;
using Eventarin.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventarin.Core.Services
{
	public interface IWebService
	{
		Task<ServiceResult<IEnumerable<Session>>> GetSessions();
	}
}


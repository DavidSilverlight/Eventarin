using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Eventarin.Android.Data.Sessions
{
	public class Result
	{
		public string id { get; set; }
		public string title { get; set; }
		public DateTime start { get; set; }
		public DateTime end { get; set; }
		public string location  { get; set; }
		public string track  { get; set; }
		public string sponsor { get; set; }
		public string speakers { get; set; }
		public string speaker_id { get; set; }
		public string content { get; set; }

	}

	public class RootObject
	{
		public List<Result> result { get; set; }
	}

}



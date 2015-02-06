using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Eventarin.Android.Data.Tracks
{
	public class Result
	{
		public string id { get; set; }
		public string room { get; set; }
		public string name  { get; set; }
		public string description  { get; set; }
	}

	public class RootObject
	{
		public List<Result> result { get; set; }
	}

}



using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Eventarin.Android.Data.Speakers
{
	public class Result
	{
		public string speaker_id { get; set; }
		public string firstname { get; set; }
		public string lastname { get; set; }
		public string avatar  { get; set; }
		public string position  { get; set; }
		public string website_url  { get; set; }
		public string company_name { get; set; }
		public string linkedin_url { get; set; }
		public string bio { get; set; }


	}

	public class RootObject
	{
		public List<Result> result { get; set; }
	}

}



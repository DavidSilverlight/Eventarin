using System;
using System.Collections.Generic;

namespace Eventarin.Data
{

	//DS 0831 - Rename  these classes, but make sure they still work well with the JSON data
	public class Result
	{
		public int speaker_id { get; set; }
		public string user_login { get; set; }
		public string firstname { get; set; }
		public string lastname { get; set; }
		public string avatar { get; set; }
		public string position { get; set; }
		public string website_url { get; set; }
		public string company_name { get; set; }
		public string linkedin_url { get; set; }
	}

	public class RootObject
	{
		public List<Result> result { get; set; }
	}

}


using System;
using Eventarin.Core.Models;
using System.Net;
using Eventarin.Android.Data.Sessions;

namespace Eventarin.Android
{
	public class EventJSONData
	{
		public EventJSONData ()
		{
		}

		public static string GetSessionDetail(int sessionId)
		{
			var url = "http://itpalooza.com/api/request.php?action=getSessionDetails&id=3519";
			//var url = "http://itpalooza.com/api/request.php?action=getSessions";
			var sesionDetails = "Details for " + url;
			var getUrl = new System.Uri(url);

			var wc = new System.Net.WebClient();
			wc.Headers ["USER-AGENT"] = "Eventarin ITPalooza HTTP client";
			wc.DownloadStringCompleted += (sender, e) => 
			{
				var v = e.Result;

				//	EventRepository.ClearSessions();
				var json = Newtonsoft.Json.JsonConvert.DeserializeObject<Data.Sessions.RootObject> (v);
				foreach ( Data.Sessions.Result session in json.result) {

					Session newSession = new Session();
					newSession.Title = session.title;
					newSession.Begins =  session.start;
					newSession.Ends = session.end;
					//	newSession.Location = "Main Hall";
					//		newSession.Abstract = "abstract for session";

					//		App.Database.AddSession(newSession);
				}
			};

			wc.DownloadStringAsync (getUrl);

			return sesionDetails;
		}





		public static void RefreshLocalSessions()
		{
			var url = "http://itpalooza.com/api/request.php?action=getSessions";
			var getUrl = new System.Uri(url);

			var wc = new System.Net.WebClient();
			wc.Headers ["USER-AGENT"] = "Eventarin ITPalooza HTTP client";
			wc.DownloadStringCompleted += (sender, e) => 
			{
				var v = e.Result;


				Eventarin.Core.App.Database.DeleteSessions();
				var json = Newtonsoft.Json.JsonConvert.DeserializeObject<Data.Sessions.RootObject> (v);
				foreach ( Data.Sessions.Result sessionJSON in json.result) {

					Session newSession = new Session();
					newSession.Id = int.Parse(sessionJSON.id);
					newSession.Title = sessionJSON.title;
					newSession.Begins =  sessionJSON.start;
					newSession.Ends = sessionJSON.end;
					newSession.Location = sessionJSON.location;


					newSession.Track = sessionJSON.track;
					newSession.Sponsor = sessionJSON.sponsor;
					newSession.Speakers = sessionJSON.speakers;
					newSession.Speaker_Id = sessionJSON.speaker_id;

					Eventarin.Core.App.Database.AddSession(newSession);
					//App.Database.AddSession(newSession);
					//	Eventarin.Core.App.Database.SaveSession(newSession);
				}

			};

			wc.DownloadStringAsync (getUrl);
		}


		public static void RefreshLocalSpeakers()
		{
			var url = "http://itpalooza.com/api/request.php?action=getSpeakers";
			var getUrl = new System.Uri(url);

			var wc = new System.Net.WebClient();
			wc.Headers ["USER-AGENT"] = "Eventarin ITPalooza HTTP client";
			wc.DownloadStringCompleted += (sender, e) => 
			{
				var v = e.Result;


				Eventarin.Core.App.Database.DeleteSpeakers();
				var json = Newtonsoft.Json.JsonConvert.DeserializeObject<Data.Speakers.RootObject> (v);
				foreach ( Data.Speakers.Result speakerJSON in json.result) {

					Speaker newSpeaker = new Speaker();
					newSpeaker.Id = int.Parse(speakerJSON.speaker_id);
					newSpeaker.Name = speakerJSON.firstname + ' ' + speakerJSON.lastname; ;
					newSpeaker.HeadshotUrl = speakerJSON.avatar;
					newSpeaker.Position = speakerJSON.position;
					newSpeaker.BioSummary = "";
					newSpeaker.Bio = "";
					//newSpeaker.Website = speakerJSON.website_url;
					newSpeaker.Company = speakerJSON.company_name;
					//newSpeaker.LinkedIn = speakerJSON.linkedin_url;
					Eventarin.Core.App.Database.AddSpeaker(newSpeaker);
					//App.Database.AddSession(newSession);
					//	Eventarin.Core.App.Database.SaveSession(newSession);
				}

			};

			wc.DownloadStringAsync (getUrl);
		}






		public static void RefreshLocalSpeakersOrig()
		{

			var url = "http://itpalooza.com/api/request.php?action=getSpeakers";
			var getUrl = new System.Uri(url);

			var wc = new WebClient();
			wc.Headers ["USER-AGENT"] = "Eventarin ITPalooza HTTP client";
	//		wc.DownloadStringCompleted += (sender2, e) => {

				//	data.Clear ();
			//	var v = e.Result;

//				//App.Database.ClearExistingSpeakers();
//				var json = Newtonsoft.Json.JsonConvert.DeserializeObject<Eventarin.Data.Speakers.RootObject> (v);
//				foreach (ITPalooza.Data.Speakers.Result speaker in json.result) {
//
//					var name = speaker.firstname + " " + speaker.lastname;
//					var twitter = "";
//					var linkedIn = speaker.linkedin_url;
//					var bio = "bio of" + name;
//					var company = speaker.company_name;
//					var headshotUrl = speaker.avatar;
//					var position = speaker.position;
//
//					var newSpeaker = new Speaker();
//					newSpeaker.Id = 0;
//					newSpeaker.Bio = bio;
//					newSpeaker.Name = name;
//					newSpeaker.TwitterHandle = twitter;
//					newSpeaker.HeadshotUrl = headshotUrl;
//
//
//					App.Database.SaveSpeaker(newSpeaker);
//			}
//			}
//			};
//
//			wc.DownloadStringAsync (getUrl);
		}

	}


}


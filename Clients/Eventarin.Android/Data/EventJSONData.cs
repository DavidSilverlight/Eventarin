using System;
using Eventarin.Core.Models;
using System.Net;
using Eventarin.Android.Data.Sessions;
using System.IO;
using System.Xml;
using System.Linq.Expressions;
using System.Linq;
using System.Xml.Serialization;
using System.Text;

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
					newSession.Abstract = sessionJSON.content;


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

		public static void RefreshLocalSpeakersXML()
		{

			Eventarin.Core.App.Database.ClearExistingSpeakers ();
			var url = "http://www.fladotnet.com/flanetdata/api/ccspeakerdetails";

			string content;

			XmlDocument doc = new XmlDocument ();
			doc.Load (url);

			int c = 0;

			foreach (XmlNode item in doc.DocumentElement.ChildNodes) {
				var speakerID = item.ChildNodes [0].InnerText;
				var speakerName =  item.ChildNodes [1].InnerText;
				var speakerImageURL = "";// "http://media.licdn.com/mpr/mpr/shrink_200_200/p/4/000/130/2c7/3c886aa.jpg";// item.ChildNodes [2].InnerText;

				try {
					speakerImageURL = item.ChildNodes [2].InnerText;
					if (speakerImageURL.Length < 10)
					{
						speakerImageURL  = "";
					}

				}
				catch(Exception exc) {
					speakerImageURL = "";

				}
				var speakerJobTitle = item.ChildNodes [3].InnerText;
				var speakerBIO = item.ChildNodes [4].InnerText;
				var speakerCompany = item.ChildNodes [5].InnerText;
				var speakderCompanyLogo = item.ChildNodes [6].InnerText;
				var speakderCompanyWebsite = item.ChildNodes [7].InnerText;




				Speaker newSpeaker = new Speaker();
				newSpeaker.Id = int.Parse(speakerID);
				newSpeaker.Name = speakerName ;
				newSpeaker.HeadshotUrl = speakerImageURL;
				newSpeaker.Position = speakerJobTitle;
				newSpeaker.Bio = speakerBIO;
				newSpeaker.BioSummary = "";
				//newSpeaker.Website = speakerJSON.website_url;
				newSpeaker.Company = speakerCompany;
				//newSpeaker.LinkedIn = speakerJSON.linkedin_url;
				Eventarin.Core.App.Database.AddSpeaker(newSpeaker);
				//App.Database.AddSession(newSession);
				//	Eventarin.Core.App.Database.SaveSession(newSession);



				c++;
			}

		}

		public static void RefreshLocalTracksXML()
		{

			Eventarin.Core.App.Database.ClearExistingTracks ();
			//var url = "http://www.fladotnet.com/flanetdata/api/ccsessions";
			var url = "http://www.fladotnet.com/flanetdata/api/cctracks";
			string content;

			XmlDocument doc = new XmlDocument ();
			doc.Load (url);

			int c = 0;

			foreach (XmlNode item in doc.DocumentElement.ChildNodes) {

				try {

				var trackID = item.ChildNodes [0].InnerText;
				var trackRoom = item.ChildNodes [1].InnerText;
				var trackName =  item.ChildNodes [2].InnerText;
				var	trackDesc = item.ChildNodes [3].InnerText;




				Track newTrack = new Track();
				newTrack.Id = int.Parse(trackID);
				newTrack.Room = trackRoom;
				newTrack.Name = trackName;
				newTrack.Description = trackDesc;


				Eventarin.Core.App.Database.AddTrack(newTrack);
				//App.Database.AddSession(newSession);
				//	Eventarin.Core.App.Database.SaveSession(newSession);

				}
				catch ( Exception exc ) {
					//Handle cases where the data is invalid
				}


				c++;
			}

		}




		public static void RefreshLocalSessionsXML()
		{

			Eventarin.Core.App.Database.ClearExistingSessions ();
			//var url = "http://www.fladotnet.com/flanetdata/api/ccsessions";
			var url = "http://www.fladotnet.com/flanetdata/api/ccsessiondetails";
			string content;

			XmlDocument doc = new XmlDocument ();
			doc.Load (url);

			int c = 0;

			foreach (XmlNode item in doc.DocumentElement.ChildNodes) {
				var sessionID = item.ChildNodes [0].InnerText;
				var speakerID = item.ChildNodes [1].InnerText;
				var sessionTitle =  item.ChildNodes [2].InnerText;
				var	sessionDesc = item.ChildNodes [3].InnerText;
				var trackID = item.ChildNodes [4].InnerText;



				Session newSession = new Session();
				newSession.Id = int.Parse(sessionID);
				newSession.Speaker_Id = speakerID;
				newSession.Title = sessionTitle;
				newSession.Abstract = sessionDesc;
				newSession.Begins = DateTime.Now;//  sessionJSON.start;
				newSession.Ends = DateTime.Now;// sessionJSON.end;
				newSession.Location = " ";  //sessionJSON.location;
				newSession.Track = "N/A";

				var track = Eventarin.Core.App.Database.GetTrack (int.Parse(trackID));
				if (track != null) {
					newSession.Track = track.Name;
				}
				//newSession.Track =" ";  //sessionJSON.track;



				newSession.Sponsor = " "; //sessionJSON.sponsor;


				newSession.Speakers = " "; //sessionJSON.speakers;
				var speaker = Eventarin.Core.App.Database.GetSpeaker (int.Parse(newSession.Speaker_Id));
				if (speaker != null) {
					newSession.Speakers = speaker.Name;
				}





				Eventarin.Core.App.Database.AddSession(newSession);
				//App.Database.AddSession(newSession);
				//	Eventarin.Core.App.Database.SaveSession(newSession);




				c++;
			}

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
					newSpeaker.Bio = speakerJSON.bio;
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


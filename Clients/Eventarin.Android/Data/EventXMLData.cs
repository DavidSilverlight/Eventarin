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
using Android.Widget;
using System.Threading.Tasks;

namespace Eventarin.Android
{
	public class EventXMLData
	{
		public EventXMLData ()
		{
		}


		public static void RefreshLocalTracksXML()
		{
			var task = Task.Factory.StartNew(() =>
			{
				try
				{
					var totalTracks = Eventarin.Core.App.Database.GetTracks().Count;
					if (totalTracks == 0)
					{
						LoadTracksXML();	
					}
					RefreshLocalSpeakersXML();
				}
				catch( Exception exc)
				{
					Toast.MakeText(null, exc.Message, ToastLength.Long).Show();
				}
			});
		}




		public static void RefreshLocalSpeakersXML()
		{
			var task = Task.Factory.StartNew(() =>
			{
				try
				{
					var totalSpeakers =  Eventarin.Core.App.Database.GetSpeakers().Count;
					if (totalSpeakers == 0)
					{
						LoadSpeakersXML();
					}
					RefreshLocalSessionsXML();

				}
				catch( Exception exc)
				{
					Toast.MakeText(null, exc.Message, ToastLength.Long).Show();
				}

			});
		}


		public static void RefreshLocalSessionsXML()
		{
			var task = Task.Factory.StartNew(() =>
			{
				try
				{
					var totalSessions =  Eventarin.Core.App.Database.GetSessions().Count;
					if (totalSessions == 0)
					{
						LoadSessionsXML();
					}
				}
				catch( Exception exc)
				{
					Toast.MakeText(null, exc.Message, ToastLength.Long).Show();
				}

			});

		}









		public static void LoadSpeakersXML()
		{

			Eventarin.Core.App.Database.ClearExistingSpeakers ();

			var doc = new XmlDocument ();
			var url = "http://www.fladotnet.com/flanetdata/api/ccspeakerdetails";
			doc.Load (url);


			foreach (XmlNode item in doc.DocumentElement.ChildNodes) 
			{
				try 
				{
					var speakerID = item.ChildNodes [0].InnerText;
					var speakerName =  item.ChildNodes [1].InnerText;
					if (speakerName.Length < 2 )
					{
						speakerName = "N/A";
					}
					var speakerImageURL = item.ChildNodes [2].InnerText;
					if (speakerImageURL.Length < 10)
					{
						speakerImageURL  = null;
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
					newSpeaker.Company = speakerCompany;
					Eventarin.Core.App.Database.AddSpeaker(newSpeaker);
				}
				catch ( Exception exc ) 
				{
					Toast.MakeText(null, exc.Message, ToastLength.Long).Show();
				}
			}


		}












		public static void LoadTracksXML()
		{

			Eventarin.Core.App.Database.ClearExistingTracks ();
			var doc = new XmlDocument ();
			var url = "http://www.fladotnet.com/flanetdata/api/cctracks";
			doc.Load (url);

			foreach (XmlNode item in doc.DocumentElement.ChildNodes) 
			{
				try 
				{
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

				}
				catch ( Exception exc ) 
				{
					Toast.MakeText(null, exc.Message, ToastLength.Long).Show();
				}
			}
		}




		public static void LoadSessionsXML()
		{

			Eventarin.Core.App.Database.ClearExistingSessions ();
			var doc = new XmlDocument ();
			var url = "http://www.fladotnet.com/flanetdata/api/ccsessiondetails";
			doc.Load (url);

			foreach (XmlNode item in doc.DocumentElement.ChildNodes) 
			{
				try 
				{
					var sessionID = item.ChildNodes [0].InnerText;
					var speakerID = item.ChildNodes [1].InnerText;
					var sessionTitle = item.ChildNodes [2].InnerText;
					var	sessionDesc = item.ChildNodes [3].InnerText;
					var trackID = item.ChildNodes [4].InnerText;

					Session newSession = new Session ();
					newSession.Id = int.Parse (sessionID);
					newSession.Speaker_Id = speakerID;
					newSession.Title = sessionTitle;
					newSession.Abstract = sessionDesc;
					newSession.Begins = DateTime.Now;//  sessionJSON.start;
					newSession.Ends = DateTime.Now;// sessionJSON.end;
					newSession.Location = " ";  //sessionJSON.location;
					newSession.Track = "N/A";

					var track = Eventarin.Core.App.Database.GetTrack (int.Parse (trackID));
					if (track != null) 
					{
						newSession.Track = track.Name;
					}

					newSession.Sponsor = " "; 
					newSession.Speakers = " "; 
					var speaker = Eventarin.Core.App.Database.GetSpeaker (int.Parse (newSession.Speaker_Id));
					if (speaker != null) 
					{
						newSession.Speakers = speaker.Name;
					}


					Eventarin.Core.App.Database.AddSession (newSession);

				} 
				catch (Exception exc) 
				{
					Toast.MakeText (null, exc.Message, ToastLength.Long);
				}

			}
		}


}
}

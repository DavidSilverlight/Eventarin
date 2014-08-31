using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using Android.Content.PM;
using Xamarin.Forms.Platform.Android;
using System.Net;
using Eventarin.Data;


namespace Eventarin.Android
{
	[Activity (Label = "Eventarin.Android.Android", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : AndroidActivity
	{
		// I apologize in advance for this awful hack, I'm sure there's a better way...
		public static MainActivity ShareActivityContext;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			ShareActivityContext = this; // HACK: for SpeakButtonRenderer to get an Activity/Context reference

			Xamarin.Forms.Forms.Init (this, bundle);
			//Xamarin.QuickUIMaps.Init (this, bundle);

			var sqliteFilename = "ITPaloozaSQLite.db3";
			string documentsPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal); // Documents folder
			var path = Path.Combine(documentsPath, sqliteFilename);

			// This is where we copy in the prepopulated database
			Console.WriteLine (path);
			if (!File.Exists(path))
			{
				var s = Resources.OpenRawResource(Resource.Raw.ITPaloozaSQLite);  // RESOURCE NAME ###

				// create a write stream
				FileStream writeStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
				// write to the stream
				ReadWriteStream(s, writeStream);
			}


			var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
			var conn = new SQLite.Net.SQLiteConnection(plat, path);

			// Set the database connection string
			App.SetDatabaseConnection (conn);

			RefreshLocalData ();

			SetPage (App.GetMainPage ());
		}


		public void RefreshLocalData()
		{

			var url = "http://itpalooza.com/api/request.php?action=getSpeakers";
			var getUrl = new System.Uri(url);

			var wc = new WebClient();
			wc.Headers ["USER-AGENT"] = "Eventarin ITPalooza HTTP client";
			wc.DownloadStringCompleted += (sender2, e) => {

				//	data.Clear ();
				var v = e.Result;

				//The Clear and Commit logic here definitely code smells
				App.Database.ClearExistingSpeakers();
				var json = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject> (v);
				foreach (Eventarin.Data.Result speaker in json.result) {

					var name = speaker.firstname + " " + speaker.lastname;
					var twitter = "";
					var linkedIn = speaker.linkedin_url;
					var bio = "bio of" + name;
					var company = speaker.company_name;
					var headshotUrl = speaker.avatar;
					var position = speaker.position;
					App.Database.AddSpeaker(name, twitter, bio, headshotUrl, company, position);
				}
				App.Database.CommitSpeakers();
				//rename RootObject


			};

			wc.DownloadStringAsync (getUrl);
		}
		void ReadWriteStream(Stream readStream, Stream writeStream)
		{
			int Length = 256;
			Byte[] buffer = new Byte[Length];
			int bytesRead = readStream.Read(buffer, 0, Length);
			// write the required bytes
			while (bytesRead > 0)
			{
				writeStream.Write(buffer, 0, bytesRead);
				bytesRead = readStream.Read(buffer, 0, Length);
			}
			readStream.Close();
			writeStream.Close();
		}

	}
}


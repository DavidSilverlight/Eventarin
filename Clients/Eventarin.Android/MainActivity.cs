using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Eventarin.Core;
using Android.Content.PM;
using System.IO;
using SQLite;
using ImageCircle.Forms.Plugin.Droid;


namespace Eventarin.Android
{
	[Activity(Label = "Eventarin.Android", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : AndroidActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate (bundle);

			Xamarin.Forms.Forms.Init (this, bundle);
		//	Xamarin.Forms.Init();//platform specific init
			ImageCircleRenderer.Init();
            
            //Initialize database
            InitializeDatabase();

			SetPage (App.GetMainPage ());
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

        public void InitializeDatabase()
        {



            //Initialize database
            var sqliteFilename = "Eventarin.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);

            // This is where we copy in the prepopulated database
            //Console.WriteLine (path);
            if (!File.Exists(path))
            {
                FileStream writeStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                using (var s = Resources.OpenRawResource(Resource.Raw.Eventarin))
                {
                    ReadWriteStream(s, writeStream);
                }  // RESOURCE NAME ###

                // create a write stream
                // write to the stream
            }


            var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);
            
          App.SetDatabaseConnection(conn);

            RefreshLocalData ();


        }


        public void RefreshLocalData()
        {
        //    EventJSONData.RefreshLocalSpeakers();
			EventJSONData.RefreshLocalSpeakersXML ();
           // EventJSONData.RefreshLocalSessions();
			EventJSONData.RefreshLocalSessionsXML();
		//	EventJSONData.GetSessionDetail (3519);
        }

	}
}



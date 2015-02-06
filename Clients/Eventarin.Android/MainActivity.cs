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
using Android.Graphics.Drawables;
//using Android.Graphics;
using Android.Graphics;


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




			//ImageView imgStatus = (ImageView) findViewById(R.id.imgInfoIcon);
			// Load the icon as drawable object
		//	Drawable d = getResources().getDrawable(R.drawable.ic_menu_info_details);

			// Get the color of the icon depending on system state
		//	int iconColor = android.graphics.Color.RED;
//				if (systemState == Status.ERROR)
//					iconColor = android.graphics.Color.RED
//				else if (systemState == Status.WARNING)
//					iconColor = android.graphics.Color.YELLOW
//				else if (systemState == Status.OK)
//					iconColor = android.graphics.Color.GREEN

					// Set the correct new color
		//			d.setColorFilter( iconColor, Mode.MULTIPLY );

				// Load the updated drawable to the image viewer
				//imgStatus.setImageDrawable(d);








			SetPage (App.GetMainPage ());
			ActionBar actionBar;// = ActionBar.SetBackgroundDrawable();

			ColorDrawable coldraw = new ColorDrawable ();
			coldraw.Color = Color.White;

			ActionBar.SetBackgroundDrawable (coldraw); //.setBackgroundDrawable(getResources().getDrawable(R.drawable.bg));
			ActionBar.SetIcon (Resource.Drawable.hamburger_menu_icon);
			ActionBar.SetTitle (Resource.String.header);
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
			var path = System.IO.Path.Combine(documentsPath, sqliteFilename);

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

           // RefreshLocalData ();
			RefreshLocalDataSequentially ();

        }


        public void RefreshLocalData()
        {

			EventXMLData.RefreshLocalTracksXML();
			EventXMLData.RefreshLocalSpeakersXML ();
			EventXMLData.RefreshLocalSessionsXML();



        //    EventJSONData.RefreshLocalSpeakers();

           // EventJSONData.RefreshLocalSessions();

		//	EventJSONData.GetSessionDetail (3519);
        }


		public void RefreshLocalDataSequentially()
		{

			EventXMLData.RefreshLocalTracksXML();
		//	EventXMLData.RefreshLocalSpeakersXML ();
		//	EventXMLData.RefreshLocalSessionsXML();

		}


	}
}



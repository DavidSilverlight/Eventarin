using System;
using SQLite.Net;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using SQLite;
using Eventarin.Core.Models;
using System.Collections.ObjectModel;



namespace Eventarin.Core.Data
{
	public class EventDatabase 
	{
		//DS 0831
		//Areas for improvement
		//1) Calling this code only at the appropriate point so that we don't make 
		//excessive calls.
		//2) Returning smaller images or converting them to smaller images in the download
		//3) Caching the images
		static object locker = new object ();

		SQLiteConnection database;

		/// <summary>
		/// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
		/// if the database doesn't exist, it will create the database and all the tables.
		/// </summary>
		/// <param name='path'>
		/// Path.
		/// </param>
		public EventDatabase(SQLiteConnection conn)
		{
			database = conn;
			// create the tables
			database.CreateTable<Speaker>();
			database.CreateTable<Session>();
		//	database.CreateTable<SessionSpeaker>();
		//	database.CreateTable<Favorite>();
		}

		#region "Speakers"

		public void ClearExistingSpeakers ()
		{
			lock (locker) {
				var speakers = database.DeleteAll<Speaker>();
			}
		}


		public ObservableCollection<Speaker> GetSpeakers () 
		{
			lock (locker) {
                var query = (from i in database.Table<Speaker>() select i).ToList<Speaker>();
                return (new ObservableCollection<Speaker>(query));
			}
		}

		public ObservableCollection<Speaker> GetMySpeakers () 
		{
			lock (locker) {
                var query = (from i in database.Table<Speaker>() select i).Take(4).ToList<Speaker>();
                return (new ObservableCollection<Speaker>(query));
			}
		}

		public Speaker GetSpeaker (int id)
		{
			lock (locker) {
				return database.Table<Speaker>().FirstOrDefault(x => x.Id == id);
			}
		}
			

		public void AddSpeaker (Speaker newSpeaker)
		{
			lock (locker) {
				database.Insert(newSpeaker);

			}
		}

        public void SaveSpeakers(ObservableCollection<Speaker> speakers)
        {

        }

		public int SaveSpeaker (Speaker item) 
		{
			lock (locker) {
				if (item.Id != 0) {
					database.Update(item);
					return item.Id;
				} else {
					return database.Insert (item);
				}
			}
		}


		public int DeleteSpeaker(Speaker speaker) 
		{
			lock (locker) {
				return database.Delete<Speaker> (speaker.Id);
			}
		}

		public int DeleteSpeakers() 
		{
			lock (locker) {
				return database.DeleteAll<Speaker>();
			}
		}


		#endregion

		#region "Sessions"

		public void ClearExistingSessions ()
		{
			lock (locker) {
				var sessions = database.DeleteAll<Session>();
			}
		}

		public Session GetSession (int sessionID)
		{
			lock (locker) {
				return database.Query<Session>(sessionID.ToString()).FirstOrDefault();
			}
		}

		public ObservableCollection<Session> GetSessions () 
		{          
                lock (locker)
                {
                    var query = (from i in database.Table<Session>() select i);

                    return (new ObservableCollection<Session>(query.ToList()));
                }
		}

        public ObservableCollection<Session>  MergeSessionChanges( ObservableCollection<Session> sessions)
        {
            var currentSessions = GetSessions();

            foreach(Session currSession in currentSessions)
            {
                //Add Logic to update only changed session objects
                            currSession.IsFavorite = true;
                        
            }

            return GetSessions();

        }

		public ObservableCollection<Session> GetMySessions () 
		{
			lock (locker) {
                var query = (from i in database.Table<Session>() select i).Take(3);
                                  //  .Where(select => select.IsFavorite).Take(5);
               
                return (new ObservableCollection<Session>(query.ToList()));
			}
		}


		public void AddSession ( Session newSession)
		{
			lock (locker) {

				database.Insert(newSession);
			}
		}

		public int SaveSession (Session item) 
		{
			lock (locker) {
				if (item.Id != 0) 
				{
					database.Update(item);
					return item.Id;
				} 
				else 
				{
					return database.Insert (item);
				}
			}
		}

        public void SaveSessions(ObservableCollection<Session> session)
        {

        }

		public int DeleteSession(Session session) 
		{
			lock (locker) {
				return database.Delete<Session> (session.Id);
			}
		}

		public int DeleteSessions() 
		{
			lock (locker) {
				return database.DeleteAll<Session>();
			}
		}

		#endregion


	}
}


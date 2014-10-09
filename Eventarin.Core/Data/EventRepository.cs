using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Eventarin.Core.Models;


namespace Eventarin.Core.Data
{
	public class EventRepository
	{
		EventDatabase db = null;
		protected static EventRepository me;	

		static EventRepository ()
		{
			me = new EventRepository();
		}
		protected EventRepository()
		{
			db = App.Database;
		}


		#region "Speakers"

		public static Speaker GetSpeaker(int id)
		{
			return me.db.GetSpeaker(id);
		}

		public static ObservableCollection<Speaker> GetSpeakers ()
		{
			return me.db.GetSpeakers();
		}

		public static void ClearSpeakers()
		{
			me.db.ClearExistingSpeakers();
		}

        public static void SaveSpeakers(ObservableCollection<Speaker> speakers)
        {
            App.Database.SaveSpeakers(speakers);
        }

		public static int SaveSpeaker (Speaker item)
		{
			return me.db.SaveSpeaker(item);
		}

		public static int DeleteSpeaker(Speaker item)
		{
			return me.db.DeleteSpeaker(item);
		}
	
		#endregion

		#region "Sessions"

		public static Session GetSession(int id)
		{
			return me.db.GetSession(id);
		}

		public static ObservableCollection<Session> GetSessions ()
		{
			return me.db.GetSessions();
		}


        public static ObservableCollection<Session> GetMySessions()
        {
            return me.db.GetMySessions();
        }

		public static void ClearSessions()
		{
			me.db.ClearExistingSessions();
		}

		public static int SaveSession (Session item)
		{
			return me.db.SaveSession(item);
		}

        public static void SaveSessions(ObservableCollection<Session> sessions)
        {
            App.Database.SaveSessions(sessions);
        }

        public static ObservableCollection<Session> MergeSessions(ObservableCollection<Session> sessions)
        {
            return me.db.MergeSessionChanges(sessions);
        }

		public static int DeleteSession(Session item)
		{
			return me.db.DeleteSession(item);
		}


		#endregion

	}
}




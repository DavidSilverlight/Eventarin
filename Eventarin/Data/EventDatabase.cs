﻿using System;
using SQLite.Net;
using System.Collections.Generic;
using System.Linq;

namespace Eventarin
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
			database.CreateTable<SessionSpeaker>();
			database.CreateTable<Favorite>();
		}

		#region "Speakers"

		public void ClearExistingSpeakers ()
		{
			lock (locker) {
				var speakers = database.Query<Speaker>("Delete from [Speaker]");
			}
		}

		public IList<Speaker> GetSpeakers ()
		{
			lock (locker) {
				var speakers = database.Query<Speaker>("SELECT * FROM [Speaker] ORDER BY [Name]");
				return speakers.ToList();
			}
		}
			
		public void AddSpeaker (string name, string twitterHandle, string bio, string headshotUrl, string company, string position)
		{
			lock (locker) {
				Speaker newSpeaker = new Speaker ();
				newSpeaker.Name = name;
				newSpeaker.TwitterHandle = twitterHandle;
				newSpeaker.Bio = bio;
				newSpeaker.HeadshotUrl = headshotUrl;
				database.Insert(newSpeaker);


				//var sql = "Insert into Speaker(Name, TwitterHandle, Bio, HeadshotUrl, Company, Position) Values ('" + name + "', '" + twitterHandle + "','" + bio + "','" + headshotUrl +  "','" + company + "','"  + position + "')";
				//var addresult = database.Query<int>(sql);

				//var speakers = database.Insert(newSpeaker);
				//database.Insert (speaker);
			//	return database.UpdateAll (speakers);
			//	return database.Update;
			}
		}

		public void CommitSpeakers ()
		{
			lock (locker) {
				database.Commit ();
			}
		}

		#endregion

		#region "Sessions"

		public IList<Session> GetSessions ()
		{
			lock (locker) {
				var sessions = database.Query<Session>("SELECT * FROM [Session] ORDER BY [Begins]");
				return sessions.ToList();
			}
		}

		#endregion

	}
}

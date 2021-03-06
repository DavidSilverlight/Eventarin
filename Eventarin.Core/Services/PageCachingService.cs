﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Reflection;
using System.Linq;

namespace Eventarin.Core.Services
{
	public class PageCachingService : IPageCachingService
	{
		public PageCachingService()
		{
			RegisteredPages = new Dictionary<Type, Page>();
		}

		protected IDictionary<Type, Page> RegisteredPages
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the page from cache or creates a new instance
		/// </summary>
		/// <returns>The page.</returns>
		/// <typeparam name="t">The type of the page to get</typeparam>
		public t GetPage<t>() where t : Page
		{
			var type = typeof(t);
			t page = default(t);
			try
			{


			//DS if (!RegisteredPages.ContainsKey(type))
				//DS{
				// If the page hasn't been cached, cache it

				// Get the constructors
				var constructorInfo = type.GetTypeInfo().DeclaredConstructors.First();
				var parms = constructorInfo.GetParameters().Select(parameter => App.SimpleIoC.Resolve(parameter.ParameterType)).ToArray();
				page = Activator.CreateInstance(type, parms) as t;


		//DS Causing an exception when accessing cached pages		RegisteredPages.Add(type, page);
				//DS		}
				//DSelse
				//DS{
				// Get it from cache
				//DS page = RegisteredPages[type] as t;
				//DS}
			}
			catch(Exception exc)
			{
				//DS Show exception message
			}
			return page;
		}

	}
}


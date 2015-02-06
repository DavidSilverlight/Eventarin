﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Eventarin.Core.ViewModels;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Eventarin.Core.Pages
{	
	public partial class SessionPage : BaseContentPage
	{	
		SessionsViewModel viewModel;

		public SessionPage ()
		{
			InitializeComponent ();
			viewModel = App.SimpleIoC.Resolve<SessionsViewModel> ();
			BindingContext = viewModel;

		}
	}
}


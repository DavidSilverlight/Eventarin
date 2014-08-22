using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(ITPalooza2014.MenuTableView), typeof(ITPalooza2014.MenuTableViewRenderer))]
namespace ITPalooza2014
{
	public class MenuTableViewRenderer : TableViewRenderer 
	{
		protected override void OnElementChanged (ElementChangedEventArgs<TableView> e)
		{
			base.OnElementChanged (e);
		
			var tableView = Control as global::Android.Widget.ListView;
			tableView.DividerHeight = 0;
			tableView.SetBackgroundColor (new global::Android.Graphics.Color(0x2C, 0x3E, 0x50));
		}
	}
}


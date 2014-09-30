using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Eventarin.Core.Views;
using Eventarin.iOS.Renderers;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Diagnostics;

[assembly:ExportRendererAttribute(typeof(PullToRefreshListView), typeof(PullToRefreshListViewRenderer))]
namespace Eventarin.iOS.Renderers
{
	public class PullToRefreshListViewRenderer : ListViewRenderer
	{
		public PullToRefreshListViewRenderer()
		{
		}

		private FormsUIRefreshControl refreshControl;

		protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
		{
			base.OnElementChanged(e);

			if (refreshControl != null)
			{
				return;
			}

			var pullToRefreshListView = (PullToRefreshListView)this.Element; 

			refreshControl = new FormsUIRefreshControl();
			refreshControl.RefreshCommand = pullToRefreshListView.RefreshCommand;
			refreshControl.Message = pullToRefreshListView.Message;
			this.Control.AddSubview(refreshControl);
			this.Control.Source = new CustomDatasource(this.Control.Source);
		}

		/// <summary>
		/// Raises the element property changed event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			var pullToRefreshListView = this.Element as PullToRefreshListView;
			if (pullToRefreshListView == null)
			{
				return;
			}


			if (e.PropertyName == PullToRefreshListView.IsRefreshingProperty.PropertyName) 
			{
				refreshControl.IsRefreshing = pullToRefreshListView.IsRefreshing;
				if (refreshControl.IsRefreshing)
				{
					// This will generate a pull if refreshing programatically
					this.Control.SetContentOffset(new System.Drawing.PointF(0.0f, -refreshControl.Frame.Size.Height), true);
				}
			} 
			else if (e.PropertyName == PullToRefreshListView.MessageProperty.PropertyName) 
			{
				refreshControl.Message = pullToRefreshListView.Message;
			} 
			else if (e.PropertyName == PullToRefreshListView.RefreshCommandProperty.PropertyName) 
			{
				refreshControl.RefreshCommand = pullToRefreshListView.RefreshCommand;
			}
		}


	}

	public class CustomDatasource : UITableViewSource
	{
		private readonly UITableViewSource underlyingTableSource;

		public CustomDatasource(UITableViewSource underlyingTableSource)
		{
			this.underlyingTableSource = underlyingTableSource;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			return this.GetCellInternal(tableView, indexPath);
		}

		public override int RowsInSection(UITableView tableview, int section)
		{
			return this.underlyingTableSource.RowsInSection(tableview, section);
		}

		public override float GetHeightForHeader(UITableView tableView, int section)
		{
			return this.underlyingTableSource.GetHeightForHeader(tableView, section);
		}

		public override UIView GetViewForHeader(UITableView tableView, int section)
		{
			return this.underlyingTableSource.GetViewForHeader(tableView, section);
		}

		public override int NumberOfSections(UITableView tableView)
		{
			return this.underlyingTableSource.NumberOfSections(tableView);
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			this.underlyingTableSource.RowSelected(tableView, indexPath);
		}

		public override string[] SectionIndexTitles(UITableView tableView)
		{
			return this.underlyingTableSource.SectionIndexTitles(tableView);
		}

		public override string TitleForHeader(UITableView tableView, int section)
		{
			return this.underlyingTableSource.TitleForHeader(tableView, section);
		}

		public override float GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			var uiCell = this.GetCellInternal(tableView, indexPath);

			uiCell.SetNeedsLayout();
			uiCell.LayoutIfNeeded();

			//var viewCell = GetPropertyValue<ViewCell>(uiCell, uiCell.GetType(), "ViewCell");

			//TODO: get the actual height here! How do we calculate it?
			return CalculateHeight(uiCell);
		}

		//TODO: this is wrong! It is very jumpy as you scroll the table up and down
		private float CalculateHeight(UITableViewCell cell)
		{
			var top = GetTop(cell);
			var bottom = GetBottom(cell);
			Debug.WriteLine(top + " " + bottom);
			return bottom - top + 20.0f;
		}
			
		private float GetBottom(UIView view, float bottom = 0.0f)
		{
			if (view.Frame.Bottom > bottom)
			{
				bottom = view.Frame.Bottom;
			}
			if (view.Subviews.Length > 0)
			{
				foreach (var subView in view.Subviews)
				{
					bottom = GetBottom(subView, bottom);
				}
			}

			return bottom;
		}

		private float GetTop(UIView view, float top = float.MaxValue)
		{
			if (view.Frame.Top < top)
			{
				top = view.Frame.Top;
			}
			if (view.Subviews.Length > 0)
			{
				foreach (var subView in view.Subviews)
				{
					top = GetTop(subView, top);
				}
			}

			return top;
		}

		private UITableViewCell GetCellInternal(UITableView tableView, NSIndexPath indexPath)
		{
			return this.underlyingTableSource.GetCell(tableView, indexPath);
		}

		public T GetPropertyValue<T>(object obj, Type type, string name)
		{
			var property = type.GetProperty(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty);
			return (T)property.GetValue(obj);
		}
	}
}


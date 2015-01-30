using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace Eventarin.Core.ViewModels
{
	public abstract class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public BaseViewModel()
		{

		}

		private bool isBusy;
		public bool IsBusy
		{
			get
			{
				return isBusy;
			}
			set
			{
				if (isBusy != value)
				{
					isBusy = value;
					RaisePropertyChanged(() => IsBusy);
				}
			}
		}

		private string _pageTitle;
		public string PageTitle
		{
			get
			{
				return _pageTitle;
			}
			set
			{
				if (_pageTitle != value)
				{
					_pageTitle = value;
					RaisePropertyChanged(() => PageTitle);
				}
			}
		}

		protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
		{
			if (PropertyChanged != null)
			{

				try
				{
					var propertyName = GetPropertyName(propertyExpression);
					var e = new PropertyChangedEventArgs(propertyName);
					PropertyChanged(this, e);
				}
				catch ( Exception exc) {
					//Do nothing
				}



			}
		}

		// Code used from MVVM Light
		protected static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
		{
			if (propertyExpression == null)
			{
				throw new ArgumentNullException("propertyExpression");
			}

			var body = propertyExpression.Body as MemberExpression;

			if (body == null)
			{
				throw new ArgumentException("Invalid argument", "propertyExpression");
			}

			var property = body.Member as PropertyInfo;

			if (property == null)
			{
				throw new ArgumentException("Argument is not a property", "propertyExpression");
			}

			return property.Name;
		}
	}
}


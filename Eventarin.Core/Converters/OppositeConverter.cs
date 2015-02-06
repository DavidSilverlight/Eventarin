using System;
using Xamarin.Forms;

namespace Eventarin.Core.Converters
{
	public class OppositeConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			bool passedInValue = (bool)value;

			return !passedInValue;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			bool passedInValue = (bool)value;

			return passedInValue;
		}
	}
}


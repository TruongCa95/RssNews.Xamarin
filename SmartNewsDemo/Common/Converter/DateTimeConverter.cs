using System;
using System.Diagnostics;
using System.Globalization;
using Xamarin.Forms;

namespace SmartNewsDemo.Converter
{
    public class DateTimeConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var inputvalue = value.ToString();
            var valueSplit = inputvalue.Substring(5, 20);
            var date = DateTime.Now - DateTime.Parse(valueSplit);
            if (date.TotalDays >= 1)
            {
                return date.Days.ToString() + " yesterday";
            }
            else if (date.TotalHours >= 1)
            {
                return date.Hours.ToString() + " hours ago";
            }
            else if (date.TotalMinutes >= 1)
            {
                return date.Minutes.ToString() + " Minutes ago";
            }
            else if (date.TotalSeconds >= 1)
            {
                return date.Seconds.ToString() + " Seconds ago";
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
       
    }
}

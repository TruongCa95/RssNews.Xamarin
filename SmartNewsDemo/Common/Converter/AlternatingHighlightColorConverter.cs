using System;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace SmartNewsDemo.Common.Converter
{
    //coloring row in listview
    public class AlternatingHighlightColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color rowcolor = Color.Transparent;
            if (value == null || parameter == null) return Color.White;
            var index = ((ListView)parameter).ItemsSource.Cast<object>().ToList().IndexOf(value);
            if (index % 2 == 0)
            {
                rowcolor = Color.FromHex("#D3D3D3");
            }
            return rowcolor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

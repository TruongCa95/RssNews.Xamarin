using System;
namespace SmartNewsDemo.Utilitis.ExtensionMethod
{
    public static class ToDoubleExtension
    {
        public static double ConvertToDouble(this double value, int digits)
        {
            double number;
            System.Globalization.CultureInfo EnglishCulture = new System.Globalization.CultureInfo("en-GB");
            if (double.TryParse(value.ToString(), System.Globalization.NumberStyles.Number, EnglishCulture, out number))
            {
                return number;
            }
            else
                return 0;
        }
    }
}

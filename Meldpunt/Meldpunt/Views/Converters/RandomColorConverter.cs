using System;
using System.Globalization;
using Xamarin.Forms;

namespace Meldpunt.Views.Converters
{
    public class RandomColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var random = new Random();
            return Color.FromRgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}


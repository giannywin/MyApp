using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace MyApp.Converters
{
    public class Base64ToImageResource : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var source = value as string;

            if (string.IsNullOrEmpty(source))
                return null;

            return ImageSource.FromStream(() =>
            {
                return new MemoryStream(System.Convert.FromBase64String(source));
            });
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

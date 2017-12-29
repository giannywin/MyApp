using System;
using System.Globalization;
using MyApp.Models;
using Xamarin.Forms;

namespace MyApp.Converters
{
    public class RecordTypeToImageResource : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var source = value as MyTaskRecordType?;

            if (source == null)
                return null;

            var assembly = "MyApp.Assets.Images";
            var imageName = "record_type_1.png";

            switch(source) {
                case MyTaskRecordType.Inspection:
                    imageName = "record_type_2.png";
                    break;
                case MyTaskRecordType.Survey:
                    imageName = "record_type_3.png";
                    break;
                case MyTaskRecordType.Metric:
                    imageName = "record_type_4.png";
                    break;
                case MyTaskRecordType.Action:
                    imageName = "record_type_5.png";
                    break;
                case MyTaskRecordType.Campaign:
                    imageName = "record_type_6.png";
                    break;
                case MyTaskRecordType.Investigation:
                    imageName = "record_type_7.png";
                    break;
                case MyTaskRecordType.MedicalRecord:
                    imageName = "record_type_8.png";
                    break;
            }

            var imagePath = $"{assembly}.{imageName}";

            return ImageSource.FromResource(imagePath);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

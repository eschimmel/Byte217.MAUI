using System.Globalization;

namespace Byte217.MAUI.Application.Maui.Converters
{
    public class StringToThickness : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = (string)value;
            string[] values = str.Split(',');

            if (values.Length == 4)
            {
                return new Thickness(double.Parse(values[0]), double.Parse(values[1]), double.Parse(values[2]), double.Parse(values[3]));
            }
            
            return new Thickness();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

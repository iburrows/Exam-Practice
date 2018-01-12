using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Example_7.Converters
{
    class IntToBrishConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int temp = (int)value;

            if (temp >= 5)
            {
                return "Green";
            }
            else if (temp >= 3)
            {
                return "Yellow";
            }
            return "Red";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Example_6.Converter
{
    class ValueToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int temp = (int)value;

            if (temp == 1 || temp == 2)
            {
                return "Green";
            }
            else if (temp == 5)
            {
                return "Red";
            }

            return "Yellow";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

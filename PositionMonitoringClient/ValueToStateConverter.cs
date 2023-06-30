using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PositionMonitoringClient
{
    [ValueConversion(typeof(object), typeof(int))]
    public class ValueToStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int valueInt;
            Int32.TryParse(value.ToString(), out valueInt);
            return valueInt == 0 ? 0 : (valueInt > 0 ? 1 : -1);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

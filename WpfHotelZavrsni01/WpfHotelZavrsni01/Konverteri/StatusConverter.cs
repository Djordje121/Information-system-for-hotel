using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfHotelZavrsni01
{
    [ValueConversion(typeof(bool),typeof(SolidColorBrush))]
    class StatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool? vl = (bool?)value;
            SolidColorBrush boja;
            if (vl == true)
                boja = new SolidColorBrush(Colors.Black);
            else if (vl == false) boja = new SolidColorBrush(Colors.Blue);

            else boja = new SolidColorBrush(Colors.Red);
            return boja;                 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

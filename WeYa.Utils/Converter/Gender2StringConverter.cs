using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace WeYa.Utils
{
    public class Gender2StringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string isgender = string.Empty;

            if (value == null)
                return isgender;
            if (value.ToString() == "f")
                return string.Format("{0}", "/Assets/Image/Common/ic_sex_female.png");

            return "/Assets/Image/Common/ic_sex_male.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value.Equals(Visibility.Visible);
        }

    }
}

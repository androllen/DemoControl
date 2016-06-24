using System;
using System.Collections.Generic;
using System.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace WeYa.Utils
{
    public class VisibilityToBooleanConverter : IValueConverter
    {
        private static readonly BooleanToVisibilityConverter BoolToVis = new BooleanToVisibilityConverter();

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return BoolToVis.ConvertBack(value, targetType, parameter, language);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return BoolToVis.Convert(value, targetType, parameter, language);
        }

    }
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var boolValue = System.Convert.ToBoolean(value);
            return boolValue ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value.Equals(Visibility.Visible);
        }

    }
}

using System;
using Windows.UI.Xaml.Data;

namespace ServInger.UI.Controls
{
    class FlagTaskCBConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (int.Parse(value.ToString()) == 0)
                return "False";
            return "True";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value.ToString() == "True")
                return 1;
            return 0;
        }
    }
}

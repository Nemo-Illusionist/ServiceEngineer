using System;
using Windows.UI.Xaml.Data;

namespace ServInger.UI.Controls {
    public class PriorityColorConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            return ((int)value).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new System.NotImplementedException();
        }
    }
}

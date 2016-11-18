using System;
using Windows.UI.Xaml.Data;

namespace ServInger.UI.Controls {
    class DataConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            return ((DateTime)value).ToString("d"/*"MM.dd.yyyy"*/);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new System.NotImplementedException();
        }
    }
}

using System;
using System.Globalization;
using Xamarin.Forms;

namespace Prism.Converters
{
    public class ItemTappedEventArgsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var itemTappedEventArgs = value as ItemTappedEventArgs;
            if (itemTappedEventArgs == null)
                throw new ArgumentException("Expected value to be of type ItemTappedEventArgs", nameof(value));
            
            return itemTappedEventArgs.Item;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ItemVisibilityEventArgsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var itemVisibilityEventArgs = value as ItemVisibilityEventArgs;
            if (itemVisibilityEventArgs == null)
                throw new ArgumentException("Expected value to be of type ItemVisibilityEventArgs", nameof(value));

            return itemVisibilityEventArgs.Item;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

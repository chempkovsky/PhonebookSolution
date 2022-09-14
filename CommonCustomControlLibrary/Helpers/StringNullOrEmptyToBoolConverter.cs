using System;
using Xamarin.Forms;

namespace CommonCustomControlLibrary.Helpers {

    public class StringNullOrEmptyToBoolConverter: IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            //if (targetType != typeof(bool))
            //    throw new InvalidOperationException("The target must be a boolean");
            var s = value as string;
            return string.IsNullOrEmpty(s);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}


using System;
using Xamarin.Forms;
using CommonInterfacesClassLibrary.Enums;

namespace CommonCustomControlLibrary.Helpers {
//    [ValueConversion(typeof(EformModeEnum), typeof(Visibility))]
    public class UpdEformModeEnumToVisibilityConverter: IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            //if (targetType != typeof(bool))
            //    throw new InvalidOperationException("The target must be a bool");
            if (value == null) return false;
            if (!(value is EformModeEnum))
                throw new InvalidOperationException("The source must be a EformModeEnum");
            if((EformModeEnum)value == EformModeEnum.UpdateMode) {
                return true;
            } else {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}


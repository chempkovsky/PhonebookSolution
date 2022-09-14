using System;
using Xamarin.Forms;

namespace CommonCustomControlLibrary.Helpers {

    public class NullableBackConverter: IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (value == null || String.IsNullOrWhiteSpace(value.ToString())) return null;
            string strval = value.ToString();
            string typeName = parameter as string;
            if(string.IsNullOrEmpty(typeName))
                throw new InvalidOperationException("Converter parameter is a required");
            typeName = typeName.ToLower().Replace("system.", "");
            if (string.IsNullOrEmpty(typeName))
                throw new InvalidOperationException("Converter parameter is required");
            switch (typeName)
            {
                case "int16":
                    {
                        Int16 v;
                        if (Int16.TryParse(strval, out v))
                            return v;
                    }
                    break;
                case "int":
                case "int32":
                    {
                        Int32 v;
                        if (Int32.TryParse(strval, out v))
                            return v;
                    }
                    break;
                case "int64":
                    {
                        Int64 v;
                        if (Int64.TryParse(strval, out v))
                            return v;
                    }
                    break;
                case "uint16":
                    {
                        UInt16 v;
                        if (UInt16.TryParse(strval, out v))
                            return v;
                    }
                    break;
                case "uint32":
                    {
                        UInt32 v;
                        if (UInt32.TryParse(strval, out v))
                            return v;
                    }
                    break;
                case "uint64":
                    {
                        UInt64 v;
                        if (UInt64.TryParse(strval, out v))
                            return v;
                    }
                    break;
                case "double":
                    {
                        Double v;
                        if (Double.TryParse(strval, out v))
                            return v;
                    }
                    break;
                case "decimal":
                    {
                        Decimal v;
                        if (Decimal.TryParse(strval, out v))
                            return v;
                    }
                    break;
                case "float":
                case "single":
                    {
                        Single v;
                        if (Single.TryParse(strval, out v))
                            return v;
                    }
                    break;
                case "date":
                case "datetime":
                    {
                        DateTime v;
                        if (DateTime.TryParse(strval, out v))
                            return v;
                    }
                    break;
                case "string":
                    return strval;
                case "guid":
                    {
                        Guid v;
                        if (Guid.TryParse(strval, out v))
                            return v;
                    }
                    break;
                default:
                    throw new InvalidOperationException("Unknown typename of converter parameter");
            }
            return null;
        }
        #endregion
    }
}


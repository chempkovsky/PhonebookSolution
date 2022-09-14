using System;

namespace CommonCustomControlLibrary.Helpers {
    public static class  ConvertHelper
    {
        public static object TryToConvert(string datatype, object val)
        {
            if ((val == null) || string.IsNullOrEmpty(datatype)) return null;
            if (val is string) { if (string.IsNullOrEmpty(val as string)) return null; }
            object result = null;
            try
            {
                switch (datatype)
                {
                    case "int16":
                        result = Convert.ToInt16(val);
                        break;
                    case "int32":
                        result = Convert.ToInt32(val);
                        break;
                    case "int64":
                        result = Convert.ToInt64(val);
                        break;
                    case "uint16":
                        result = Convert.ToUInt16(val);
                        break;
                    case "uint32":
                        result = Convert.ToUInt32(val);
                        break;
                    case "uint64":
                        result = Convert.ToUInt64(val);
                        break;
                    case "double":
                        result = Convert.ToDouble(val);
                        break;
                    case "decimal":
                        result = Convert.ToDecimal(val);
                        break;
                    case "single":
                        result = Convert.ToSingle(val);
                        break;
                    case "date":
                    case "datetime":
                        result = Convert.ToDateTime(val);
                        break;
                    case "string":
                        result = val as string;
                        break;
                    case "guid":
                        {
                            string s = val as string;
                            Guid g;
                            if(Guid.TryParse(s, out g)) {
                                result = g;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch { }
            return result;
        }
    }
}


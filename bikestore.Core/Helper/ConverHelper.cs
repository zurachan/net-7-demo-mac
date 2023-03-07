using System.Data;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Newtonsoft.Json;

namespace bikestore.Core.Helper
{
    public class ConvertHelper
    {
        public static object ConvertByType(Type type, object objConvert)
        {
            switch (type.Name)
            {
                case "String":
                    return ToString(objConvert);

                case "Int":
                    return ToInt32(objConvert);

                case "Double":
                    return ToDouble(objConvert);

                case "DateTime":
                    return ToDateTime(objConvert);

                case "Decimal":
                    return ToDecimal(objConvert);

                case "Float":
                    return ToInt64(objConvert);

                case "Guid":
                    return ToGuid(objConvert.ToString());

                case "Bool":
                    return ToBoolean(objConvert);

                case "Boolean":
                    return ToBoolean(objConvert);

                case "Int16":
                    return ToInt16(objConvert);

                case "Int32":
                    return ToInt32(objConvert);

                case "Int64":
                    return ToInt64(objConvert);

                case "Byte":
                    return ToByte(objConvert);
            }

            return null;
        }

        public static List<U> ConvertList<U, T>(List<T> listObject)
        {
            if (listObject == null)
            {
                return null;
            }

            List<U> uList = new List<U>();
            foreach (T t in listObject)
            {
                if (t != null)
                {
                    U uDefault = default(U);
                    U u = ConvertObject<U>(t, uDefault);
                    uList.Add(u);
                }
            }

            return uList;
        }

        public static T ConvertObject<T>(object t, T defaultValue)
        {
            T obj = default(T);
            try
            {
                obj = (T)t;
            }
            catch (InvalidCastException)
            {
                return defaultValue;
            }
            catch (ArgumentNullException)
            {
                return defaultValue;
            }

            return obj;
        }

        public static bool ToBoolean(object obj)
        {
            bool retVal;

            if (obj == null)
            {
                return false;
            }

            return (bool.TryParse(obj.ToString(), out retVal) && retVal);
        }

        public static byte ToByte(object obj)
        {
            return ToByte(obj, 0xff);
        }

        public static byte ToByte(object obj, byte defaultValue)
        {
            byte retVal;
            if ((obj != null) && byte.TryParse(obj.ToString(), out retVal))
            {
                return retVal;
            }

            return defaultValue;
        }

        public static DateTime ToDateTime(object obj)
        {
            return ToDateTime(obj, DateTime.Now);
        }

        public static DateTime ToDateTime(object obj, DateTime defaultValue)
        {
            DateTime retVal;
            if (obj == null)
            {
                return defaultValue;
            }
            if (!DateTime.TryParse(obj.ToString(), out retVal))
            {
                retVal = defaultValue;
            }

            return retVal;
        }

        public static DateTime ToDateTimeExact(object obj, string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
            {
                pattern = "dd/MM/yyyy";
            }

            DateTime retVal;
            if (obj == null)
            {
                return DateTime.MinValue;
            }

            if (!DateTime.TryParseExact(obj.ToString(), pattern, null, DateTimeStyles.None, out retVal))
            {
                retVal = DateTime.Now;
                if (retVal == new DateTime(1, 1, 1))
                {
                    return DateTime.MinValue;
                }
            }

            return retVal;
        }

        public static DateTime ToDateTimeExact(object obj, string pattern, DateTime defaultValue)
        {
            if (string.IsNullOrEmpty(pattern))
            {
                pattern = "dd/MM/yyyy";
            }

            DateTime retVal;
            if (obj == null)
            {
                return DateTime.MinValue;
            }

            if (!DateTime.TryParseExact(obj.ToString(), pattern, null, DateTimeStyles.None, out retVal))
            {
                retVal = defaultValue;
            }

            return retVal;
        }

        public static decimal ToDecimal(object obj)
        {
            return ToDecimal(obj, 0M);
        }

        public static decimal ToDecimal(object obj, decimal defaultValue)
        {
            decimal retVal;

            if ((obj != null) && decimal.TryParse(obj.ToString(), out retVal))
            {
                return retVal;
            }

            return defaultValue;
        }

        public static double ToDouble(object obj)
        {
            return ToDouble(obj, 0.0);
        }

        public static double ToDouble(object obj, double defaultValue)
        {
            double retVal;

            if ((obj != null) && double.TryParse(obj.ToString(), out retVal))
            {
                return retVal;
            }

            return defaultValue;
        }

        public static Guid ToGuid(object obj, Guid defaultValue)
        {
            if (obj == null)
            {
                return defaultValue;
            }

            Guid retVal = defaultValue;
            try
            {
                retVal = ToGuid(obj);
            }
            catch (Exception)
            {
                retVal = defaultValue;
            }

            return retVal;
        }

        public static short ToInt16(object obj)
        {
            return ToInt16(obj, 0);
        }

        public static short ToInt16(object obj, short defaultValue)
        {
            short retVal;

            if ((obj != null) && short.TryParse(obj.ToString(), out retVal))
            {
                return retVal;
            }

            return defaultValue;
        }

        public static int ToInt32(object obj)
        {
            return ToInt32(obj, 0);
        }

        public static int? ToInt32(IDataReader dr, string objectName)
        {
            if (dr[objectName] == DBNull.Value)
            {
                return null;
            }
            return ToInt32(dr[objectName], 0);
        }

        public static int ToInt32(object obj, int defaultValue)
        {
            int retVal;

            if (obj == null)
            {
                return 0;
            }
            if (int.TryParse(obj.ToString(), out retVal))
            {
                return retVal;
            }

            return defaultValue;
        }

        public static int ToInteger(object obj)
        {
            return ToInt32(obj);
        }

        public static long ToInt64(object obj)
        {
            return ToInt64(obj, 0L);
        }

        public static long ToInt64(object obj, long defaultValue)
        {
            long retVal;
            if ((obj != null) && long.TryParse(obj.ToString(), out retVal))
            {
                return retVal;
            }

            return defaultValue;
        }

        public static string ToString(object obj)
        {
            return ToString(obj, string.Empty);
        }

        public static string ToString(object obj, string defaultValue)
        {
            if (obj == null)
            {
                return defaultValue;
            }

            string retVal = obj.ToString();
            if (string.IsNullOrEmpty(retVal))
            {
                retVal = defaultValue;
            }

            return retVal;
        }

        public static string ToDateString(DateTime dt)
        {
            // If datatype is DateTime, then nothing else is necessary. 
            if (dt == DateTime.MinValue)
            {
                return string.Empty;
            }

            return dt.ToString("dd/MM/yyyy");
        }

        public static string ToTimeString(DateTime dt)
        {
            // If datatype is DateTime, then nothing else is necessary. 
            if (dt == DateTime.MinValue)
            {
                return string.Empty;
            }

            return dt.ToShortTimeString();
        }

        public static Guid ToGuid(object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return Guid.Empty;

            // If datatype is Guid, then nothing else is necessary. 
            if (obj.GetType() == Type.GetType("System.Guid"))
                return (Guid)obj;

            string str = obj.ToString();
            if (str == string.Empty)
                return Guid.Empty;

            return XmlConvert.ToGuid(str);
        }

        public static bool IsEmptyGuid(Guid g)
        {
            if (g == Guid.Empty)
                return true;

            return false;
        }

        public static bool IsEmptyGuid(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return true;
            }

            string s = obj.ToString();
            if (s == string.Empty)
            {
                return true;
            }

            Guid g = XmlConvert.ToGuid(s);
            if (g == Guid.Empty)
                return true;
            return false;
        }

        public static byte[] ToBinary(object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return new byte[0];
            return (byte[])obj;
        }

        public static object ToDBGuid(Guid g)
        {
            if (g == Guid.Empty)
                return DBNull.Value;
            return g;
        }

        public static object ToDBGuid(object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return DBNull.Value;
            // If datatype is Guid, then nothing else is necessary. 
            if (obj.GetType() == Type.GetType("System.Guid"))
                return obj;

            string str = obj.ToString();
            if (str == string.Empty)
                return DBNull.Value;

            Guid g = XmlConvert.ToGuid(str);
            if (g == Guid.Empty)
                return DBNull.Value;

            return g;
        }

        public static string ToBase64(string data)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(data));
        }

        public static string ObjectToJsonString(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static string ToPascalCase(string input)
        {
            var result = string.Empty;

            var parts = input.Split('_');
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            foreach (var s in parts)
            {
                result += textInfo.ToTitleCase(s.ToLower());
            }

            return result;
        }

        public static List<T> ToList<T>(IDataReader dr)
        {
            List<T> list = new List<T>();
            try
            {
                T obj = default(T);
                while (dr.Read())
                {
                    obj = Activator.CreateInstance<T>();
                    foreach (PropertyInfo prop in obj.GetType().GetProperties())
                    {
                        var col = GetDbColumnName(dr, prop.Name);
                        if (!dr.HasColumn(col)) continue;
                        if (!Equals(dr[col], DBNull.Value))
                        {
                            prop.SetValue(obj, dr[col], null);
                        }
                    }
                    list.Add(obj);
                }
            }
            finally
            {
                dr.Close();
            }

            return list;
        }

        public static List<T> ToList<T>(DataTable dt)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            foreach (DataRow dr in dt.Rows)
            {
                obj = ToObject<T>(dr);
                list.Add(obj);
            }

            return list;
        }

        public static List<T> ToList<T>(IEnumerable<DataRow> rows)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            foreach (DataRow dr in rows)
            {
                obj = ToObject<T>(dr);
                list.Add(obj);
            }
            return list;
        }

        public static T ToObject<T>(DataRow dr)
        {
            T obj = default(T);
            foreach (DataColumn column in dr.Table.Columns)
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    var col = GetDbColumnName(dr.Table, prop.Name);
                    if (!dr.Table.Columns.Contains(col)) continue;
                    if (!Equals(dr[col], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[col], null);
                    }
                }
            }

            return obj;
        }

        private static string GetDbColumnName(IDataRecord dr, string propertyName)
        {
            var dbColumnName = propertyName;
            for (int i = 0; i < dr.FieldCount; i++)
            {
                var dbName = dr.GetName(i);
                var pascalCaseColumnName = ToPascalCase(dbName);
                if (pascalCaseColumnName.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return dbName;
                }
            }

            return dbColumnName;
        }

        private static string GetDbColumnName(DataTable dt, string propertyName)
        {
            var dbColumnName = propertyName;
            foreach (DataColumn column in dt.Columns)
            {
                var dbName = column.ColumnName;
                var pascalCaseColumnName = ToPascalCase(dbName);
                if (pascalCaseColumnName.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return dbName;
                }
            }

            return dbColumnName;
        }

        public static string CleanerWords(string inputString)
        {
            if (!string.IsNullOrEmpty(inputString))
            {
                var bannedWords = @"\b(insert|update|delete|drop|grant|grant|exec|execute|select|\|/|-|#|%|cr|lf|null|sub)\b";
                var result = Regex.Replace(inputString, bannedWords, "", RegexOptions.IgnoreCase);
                return result;
            }
            return string.Empty;
        }

        public static DataTable ToDataTable<T>(List<T> models)
        {
            // creating a data table instance and typed it as our incoming model   
            // as I make it generic, if you want, you can make it the model typed you want.  
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties of that model  
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Loop through all the properties              
            // Adding Column name to our datatable  
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names    
                dataTable.Columns.Add(prop.Name);
            }
            // Adding Row and its value to our dataTable  
            foreach (T item in models)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows    
                    values[i] = Props[i].GetValue(item, null);
                }
                // Finally add value to datatable    
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
    }
}


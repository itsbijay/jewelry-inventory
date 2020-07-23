using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using System.IO;
using System.ComponentModel;

namespace Connections
{
    public static class Extenstions
    {
        public static T FieldOrDefault<T>(this DataRow row, string columnName)
        {
            return row.IsNull(columnName) ? default(T) : row.Field<T>(columnName);
        }

        public static String ErrorMessageString(this Dictionary<String, String> collection)
        {
            var sbr = new StringBuilder();
            sbr.Append("Following errors occoured." + Environment.NewLine);
            sbr.Append("=====================================" + Environment.NewLine + Environment.NewLine);

            foreach (var error in collection)
                sbr.Append(error.Value + Environment.NewLine);

            return sbr.ToString();
        }

        /// <summary>
        /// Converting IEnumerable to Data table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> collection)
        {
            var dt = new DataTable();
            var t = typeof(T);
            var pia = t.GetProperties();
            //Create the columns in the DataTable
            foreach (PropertyInfo pi in pia)
            {
                dt.Columns.Add(pi.Name, pi.PropertyType);
            }
            //Populate the table
            foreach (T item in collection)
            {
                var dr = dt.NewRow();
                dr.BeginEdit();
                foreach (PropertyInfo pi in pia)
                {
                    dr[pi.Name] = pi.GetValue(item, null);
                }
                dr.EndEdit();
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public static void WriteTo(this Stream sourceStream, Stream targetStream)
        {
            var buffer = new byte[0x10000];
            int n;
            while ((n = sourceStream.Read(buffer, 0, buffer.Length)) != 0)
                targetStream.Write(buffer, 0, n);
        }

        public static string GetDescription(this Enum en)
        {
            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return en.ToString();
        }
    }
}

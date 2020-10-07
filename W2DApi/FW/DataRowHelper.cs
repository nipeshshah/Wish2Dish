using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2DApi.SQL
{
    public class SQLDataRowHelper
    {
        public bool Equals<T>(DataRow row, string ColumnName, T CompareValue)
        {
            if (typeof(T) == typeof(string))
            {
                string rowValue = row[ColumnName]?.ToString().ToLower();
                return rowValue == (string)(object)CompareValue.ToString().ToLower();
            }
            return false;
        }

        public bool NotEquals<T>(DataRow row, string ColumnName, T CompareValue)
        {
            return ! Equals<T>(row, ColumnName, CompareValue);
        }

        public T GetValue<T>(DataRow row, string columnName)
        {
            if (row.Field<T>(columnName) == null)
            {
                if (typeof(T) == typeof(int))
                    return (T)(object)-1;
                else if (typeof(T) == typeof(string))
                    return (T)(object)string.Empty;
                else
                    return (T)(object)null;
            }
            else
            {
                return row.Field<T>(columnName);
            }
        }
    }
}

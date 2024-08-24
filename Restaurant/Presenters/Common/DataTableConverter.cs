using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Presenters.Common
{
    public class DataTableConverter
    {
        public static DataTable ConvertToDataTable<T>(List<T> data)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            // Get properties of the model type
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Create columns based on properties, excluding those with [Browsable(false)] from visible columns
            foreach (PropertyInfo prop in properties)
            {
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            // Populate the DataTable with data from the list
            foreach (T item in data)
            {
                var values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(item) ?? DBNull.Value;
                }
                dataTable.Rows.Add(values);
            }

            // Hide columns that are marked with [Browsable(false)]
            foreach (PropertyInfo prop in properties)
            {
                var browsableAttribute = prop.GetCustomAttribute<BrowsableAttribute>();
                if (browsableAttribute != null && !browsableAttribute.Browsable)
                {
                    dataTable.Columns[prop.Name].ColumnMapping = MappingType.Hidden;
                }
            }

            return dataTable;
        }
    }
}

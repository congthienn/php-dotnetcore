using System.Data;
using System.Reflection;

namespace BookStoreDesktop.Datatable
{
    static class ConvertDataTable
    {
        public static DataTable ToDataTable<T>(List<T> listItems)
        {
            DataTable dataTable = new DataTable();
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in listItems)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
    }
}

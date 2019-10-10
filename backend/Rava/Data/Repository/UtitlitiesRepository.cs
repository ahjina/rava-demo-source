using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Data.Repository
{
    public class UtitlitiesRepository: DataContext
    {
        private IDataContext context;
        public string CreateNewCode(string TableName, string ColumnName)
        {
            string result = string.Empty;

            string query = "SELECT MAX(" + ColumnName + ") FROM " + TableName;

            DataTable dt = ExecuteDataTable(query, null, CommandType.Text);

            if (dt == null || dt.Rows.Count == 0) result = ColumnName + "-001";
            else
            {
                string currentValue = dt.Rows[0][0].ToString();
                int currentId = Convert.ToInt32(currentValue.Split('-')[1]);
                int newId = currentId + 1;

                switch (newId.ToString().Length)
                {
                    case 1: result = TableName.ToUpper() + "-00" + newId; break;
                    case 2: result = TableName.ToUpper() + "-0" + newId; break;
                    case 3: result = TableName.ToUpper() + "-" + newId; break;
                }
            }

            return result;
        }
    }
}

using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace Data
{
    public interface IDataContext
    {
        int ExecuteNonQuery(string query, params object[] parameters);
        DataSet ExecuteDataSet(string query, SqlParameter[] parameters = null);
        DataTable ExecuteDataTable(string query, SqlParameter[] parameters = null, CommandType commandType = CommandType.StoredProcedure);
    }
}

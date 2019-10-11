using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Data
{
    public interface IDataContext
    {
        int ExecuteNonQuery(string query, SqlParameter[] parameters = null);
        DataSet ExecuteDataSet(string query, SqlParameter[] parameters = null);
        DataTable ExecuteDataTable(string query, SqlParameter[] parameters = null, CommandType commandType = CommandType.StoredProcedure);
    }
}

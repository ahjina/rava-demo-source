using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Data
{
    interface IDataContext
    {
        int ExecuteNonQuery(string query, SqlParameter[] parameters);
        DataSet ExecuteDataSet(string query, SqlParameter[] parameters);
        DataTable ExecuteDataTable(string query, SqlParameter[] parameters);
    }
}

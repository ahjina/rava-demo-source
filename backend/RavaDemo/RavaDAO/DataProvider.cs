using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Data;
//using Microsoft.Extensions.Configuration;

namespace Rava.Data
{
    public class DataProvider
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //static string path = Path.GetFullPath(Environment.CurrentDirectory);
        //static string databaseName = "NhaHang.mdf";
        //public static string StrChuoiKetNoi = @"Data Source=(localdb)\v11.0;AttachDbFilename=" + path + @"\" + databaseName + ";Integrated Security=True";
        public static string ConnectionString = @"Data Source=DESKTOP-K2D3HBN\SQLEXPRESS;Initial Catalog=dbDemo;Integrated Security=True;";
        //public static SqlConnection CreateConnection()
        //{
           
        //    var conn = new SqlConnection(ConnectionString);

        //    try
        //    {
        //        if (conn.State != ConnectionState.Open)
        //        {
        //            conn.Open();
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //    return conn;
        //}

        //public static DataTable ExecuteDataTable(string cautruyvan, SqlParameter[] param)
        //{
        //    var conn = CreateConnection();
        //    DataTable dt = new DataTable();
        //   try
        //    {
        //        SqlCommand cmd = conn.CreateCommand();
        //        cmd.CommandText = cautruyvan;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddRange(param);
        //        using (SqlDataReader sdr = cmd.ExecuteReader())
        //        {
        //            dt.Load(sdr);
        //            sdr.Close();
        //        }
              
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //    finally
        //    {
        //        if (conn.State != ConnectionState.Closed)
        //        {
        //            conn.Close();
        //        }
        //    }

        //    return dt;

        //}

        //public int ExecuteNonQuery(string cautruyvan, SqlParameter[] param, int? Timeout = 300,bool Transaction = false )
        //{
        //    var conn = CreateConnection();

        //    try
        //    {

        //        int result = -1;

        //        using (var cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = cautruyvan;
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            if (param != null)
        //                cmd.Parameters.AddRange(param);
        //            if (Timeout != null)
        //                cmd.CommandTimeout = Timeout.Value;
        //            if (!Transaction)
        //            {
        //                using (var dbTransaction = conn.BeginTransaction())
        //                {
        //                    try
        //                    {
        //                        cmd.Transaction = dbTransaction;
        //                        result = cmd.ExecuteNonQuery();
        //                        dbTransaction.Commit();
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        if (!Transaction)
        //                        {
        //                            dbTransaction.Rollback();
        //                        }
        //                        throw ex;
        //                    }
        //                }
        //            }
        //            else
        //                result = cmd.ExecuteNonQuery();
        //        }
        //        return result;
        //    }
        //    finally
        //    {
        //        if (conn.State != ConnectionState.Closed)
        //        {
        //            conn.Close();
        //        }
        //    }

        //}
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;


namespace Data
{
    public class DataContext: DbContext
    {
        protected DataContext() { }
        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        public string ConnectionString = null;
        public DataContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrWhiteSpace(ConnectionString))
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        public int ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            var conn = Database.GetDbConnection();

            var command = conn.CreateCommand();
            command.CommandText = query;
            command.CommandType = CommandType.StoredProcedure;

            if (parameters != null)
                command.Parameters.AddRange(parameters);

            return command.ExecuteNonQuery();
        }

        public DataSet ExecuteDataSet(string query, SqlParameter[] parameters)
        {
            var conn = Database.GetDbConnection();
            DataSet ds = new DataSet();

            try
            {
                var command = conn.CreateCommand();
                command.CommandText = query;
                command.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                using (DbDataAdapter dataAdapter = new SqlDataAdapter((SqlCommand)command))
                {
                    dataAdapter.Fill(ds);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            return ds;
        }

        public DataTable ExecuteDataTable(string query, SqlParameter[] parameters)
        {
            var conn = Database.GetDbConnection();
            DataTable dt = new DataTable();

            try
            {
                var command = conn.CreateCommand();
                command.CommandText = query;
                command.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                using (var reader = command.ExecuteReader())
                {
                    dt.Load(reader);
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            return dt;
        }
    }
}

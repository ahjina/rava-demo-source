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
using Model.Product;

namespace Data
{
    public class DataContext : DbContext, IDataContext
    {
        protected DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public string ConnectionString = null;

        public DataContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductEntity>().HasKey(p => p.ProductCode);
            builder.Entity<ProductEntity>().ToTable("Product");

            builder.Entity<AttributeDetailEntity>().HasKey(p => new { p.ProductCode, p.AttributeCode });
            builder.Entity<AttributeDetailEntity>().ToTable("AttributeDetail");

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

        // Register Entities
        public DbSet<ProductEntity> ProductEntity { get; set; }
        public DbSet<AttributeDetailEntity> AttributeDetailEntity { get; set; }


        public int ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            var conn = Database.GetDbConnection();

            if (conn.State != ConnectionState.Open) conn.Open();

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

            if (conn.State != ConnectionState.Open) conn.Open();

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

        public DataTable ExecuteDataTable(string query, SqlParameter[] parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            var conn = Database.GetDbConnection();
            DataTable dt = new DataTable();

            if (conn.State != ConnectionState.Open) conn.Open();

            try
            {
                var command = conn.CreateCommand();
                command.CommandText = query;
                command.CommandType = commandType;
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

        #region Product
        public DataTable ProductFilter(string ProductCode, string Name, int? Type)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@ProductCode", ProductCode),
                new SqlParameter("@Name", Name),
                new SqlParameter("@Type", Type)
            };

            return ExecuteDataTable("[dbo].[Products.Filter]", parameters);
        }

        public int InsertProduct(string ProductCode, string Name, int? Type, decimal Price, DataTable TbDetail)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@ProductCode", ProductCode),
                new SqlParameter("@Name", Name),
                new SqlParameter("@Type", Type),
                new SqlParameter("@Price", Price),
                new SqlParameter("@TbDetail", TbDetail)
            };

            return ExecuteNonQuery("[dbo].[Product.Insert]", parameters);
        }
        #endregion

        #region Utilities

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
        #endregion
    }
}

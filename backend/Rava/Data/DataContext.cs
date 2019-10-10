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

        public string ConnectionString = string.Empty;

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
    }
}

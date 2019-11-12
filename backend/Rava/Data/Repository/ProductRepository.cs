using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Data.Repository
{
    public class ProductRepository
    {
        private readonly IDataContext _context;

        public ProductRepository(IDataContext context)
        {
            _context = context;
        }

        public DataTable ProductFilter(string ProductCode, string Name, int? Type)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@ProductCode", ProductCode),
                new SqlParameter("@Name", Name),
                new SqlParameter("@Type", Type)
            };

            return _context.ExecuteDataTable("[dbo].[Products.Filter]", parameters);
        }

        public int InsertProduct(string @ProductCode, string @Name, int? @Type, decimal @Price, DataTable @TbDetail)
        {
            //SqlParameter[] parameters =
            //{
            //    new SqlParameter("@ProductCode", ProductCode),
            //    new SqlParameter("@Name", Name),
            //    new SqlParameter("@Type", Type),
            //    new SqlParameter("@Price", Price),
            //    new SqlParameter("@TbDetail", TbDetail)
            //};

            return _context.ExecuteNonQuery("[dbo].[Product.Insert]", @ProductCode, @Name, @Type, @Price, @TbDetail);
        }

        public DataTable GetProductByCode(string ProductCode)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@ProductCode", ProductCode)
            };

            return _context.ExecuteDataTable("[dbo].[Product.GetByProductCode]", parameters);
        }

        public DataTable GetTopLasted()
        {
            return _context.ExecuteDataTable("[dbo].[Product.GetTopLasted]");
        }
    }
}

using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Data.Repository
{
    public class ProductRepository: DataContext
    {
        public DataTable Filter(int? Type)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Type", Type)
            };

            return DataContext.ExecuteDataTable("[dbo].[Products.Filter]", parameters);
        }
    }
}

using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Data.Repository
{
    public class MasterDataRepository
    {
        private IDataContext _context;

        public MasterDataRepository(IDataContext context)
        {
            _context = context;
        }

        public DataTable GetListByGroupCode(string GroupCode)
        {
            SqlParameter[] parameter = 
            {
                new SqlParameter("@GroupCode", GroupCode)
            };

            return _context.ExecuteDataTable("[dbo].[MasterData.GetListByGroupCode]", parameter);
        }

        public int Insert(string GroupCode, int Id, string Code, string Name, int? Order)
        {
            SqlParameter[] parameter =
            {
                new SqlParameter("@GroupCode", GroupCode),
                new SqlParameter("@Id", Id),
                new SqlParameter("@Code", Code),
                new SqlParameter("@Name", Name),
                new SqlParameter("@Order", Order)
            };

            return _context.ExecuteNonQuery("[dbo].[MasterData.Insert]", parameter);
        }
    }
}

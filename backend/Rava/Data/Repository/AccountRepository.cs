using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Data.Repository
{
    public class AccountRepository
    {
        private IDataContext _context;

        public AccountRepository(IDataContext context)
        {
            _context = context;
        }

        public DataTable GetAccount(string phone)
        {

            SqlParameter[] par =
            {
                new SqlParameter("Phone",phone),
                new SqlParameter("Password", "123")
            };

            DataTable dtAcc = _context.ExecuteDataTable("[Account].[CheckLogin]", par);
            return dtAcc;
        }
    }
}

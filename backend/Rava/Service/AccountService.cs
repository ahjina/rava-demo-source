using Data;
using Data.Repository;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Service
{
    public class AccountService : IAccountService
    {
        private AccountRepository _repository;

        public AccountService(IDataContext _context)
        {
            _repository = new AccountRepository(_context);
        }

        public DataTable GetAccount(string phone)
        {
            return _repository.GetAccount(phone);
        }
    }
}

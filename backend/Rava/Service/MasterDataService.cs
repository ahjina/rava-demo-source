using Data;
using Data.Repository;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Service
{
    public class MasterDataService : IMasterDataService
    {
        private MasterDataRepository _repository;

        public MasterDataService(IDataContext _context)
        {
            _repository = new MasterDataRepository(_context);
        }

        public DataTable GetListByGroupCode(string GroupCode)
        {
            return _repository.GetListByGroupCode(GroupCode);
        }

        public int Insert(string GroupCode, string Code, string Name, int? Order)
        {
            return _repository.Insert(GroupCode, Code, Name, Order);
        }
    }
}

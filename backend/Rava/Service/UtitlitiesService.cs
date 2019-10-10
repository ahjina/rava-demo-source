using Data;
using Data.Repository;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class UtitlitiesService: IUtitlitiesService
    {
        private UtitlitiesRepository _repository;

        public UtitlitiesService(IDataContext _context)
        {
            _repository = new UtitlitiesRepository(_context);
        }

        public string CreateNewCode(string TableName, string ColumnName)
        {
            return _repository.CreateNewCode(TableName, ColumnName);
        }
    }
}

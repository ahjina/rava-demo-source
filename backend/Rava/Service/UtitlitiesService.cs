using Data;
using Data.Repository;
using Services.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
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

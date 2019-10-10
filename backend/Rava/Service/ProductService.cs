using Data;
using Data.Repository;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Service
{
    public class ProductService: IProductService
    {
        ProductRepository _repository;

        public ProductService(IDataContext _context)
        {
            _repository = new ProductRepository(_context);
        }

        public DataTable ProductFilter(string ProductCode, string Name, int? Type)
        {
            return _repository.ProductFilter(ProductCode, Name, Type);
        }

        public int InsertProduct(string ProductCode, string Name, int? Type, decimal Price, DataTable TbDetail)
        {
            return _repository.InsertProduct(ProductCode, Name, Type, Price, TbDetail);
        }

        public DataTable GetProductByCode(string ProductCode)
        {
            return _repository.GetProductByCode(ProductCode);
        }
    }
}

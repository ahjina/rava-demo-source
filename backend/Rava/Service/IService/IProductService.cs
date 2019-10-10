using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Services.IService
{
    public interface IProductService
    {
        DataTable ProductFilter(string ProductCode, string Name, int? Type);
        int InsertProduct(string ProductCode, string Name, int? Type, decimal Price, DataTable TbDetail);
        DataTable GetProductByCode(string ProductCode);
    }
}

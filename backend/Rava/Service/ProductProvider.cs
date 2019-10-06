using Data.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Service
{
    public class ProductProvider
    {
        ProductRepository repository = new ProductRepository();

        public DataTable Filter(int? Type)
        {
            return repository.Filter(Type);
        }
    }
}

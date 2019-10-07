using Model.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Model.Product
{
    public class ProductModel
    {
        public ProductEntity Product { get; set; }
        public List<AttributeDetailEntity> Details { get; set; }
    }
}

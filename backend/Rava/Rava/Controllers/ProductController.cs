using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model.Model.Product;
using Model.Product;

namespace Rava.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("[action]")]
        public IActionResult Filter(ProductEntity _object)
        {
            return Ok(_context.ProductFilter(_object.ProductCode, _object.Name, _object.Type));
        }

        [HttpPost("[action]")]
        public IActionResult Insert(ProductModel _object)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Code", typeof(string));
            dt.Columns.Add("AttributeCode", typeof(string));
            dt.Columns.Add("Value", typeof(string));

            if(_object.Details != null && _object.Details.Count > 0)
            {
                foreach (var item in _object.Details)
                {
                    DataRow dr = dt.NewRow();
                }
            }

            var result = _context.InsertProduct(_object.Product.ProductCode, _object.Product.Name, _object.Product.Type, Convert.ToDecimal(_object.Product.Price), dt);

            return Ok();
        }
    }
}
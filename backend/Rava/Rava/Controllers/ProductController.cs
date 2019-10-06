using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service;

namespace Rava.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : RavaController
    {
        private readonly ProductProvider _productProvider;

        public ProductController(ProductProvider productProvider, IConfiguration configuration)
        {
            _productProvider = productProvider;
        }

        [HttpPost("[action]")]
        public IActionResult Filter(int? Type)
        {
            return Ok(_productProvider.Filter(Type));
        }
    }
}
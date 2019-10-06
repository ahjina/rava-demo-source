using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rava.Controllers
{
    public class RavaController: ControllerBase
    {
        protected DataContext DbContext;

        public RavaController(DataContext context)
        {
            DbContext = context;
        }
    }
}

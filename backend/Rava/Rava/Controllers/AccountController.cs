using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Data;
using Service.IService;

namespace Rava.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountService _AccountService;
        private IUtitlitiesService _utilitiesService;

        public AccountController(IAccountService AccountService, IUtitlitiesService utitlitiesService)
        {
            _AccountService = AccountService;
            _utilitiesService = utitlitiesService;
        }
        // GET: api/Account
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public IActionResult CheckLogin(string id)
        {
            return Ok(_AccountService.GetAccount(id));
        }


      
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entity.MasterData;
using Service.IService;

namespace Rava.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private IMasterDataService _masterDataService;

        public CommonController(IMasterDataService masterDataService)
        {
            _masterDataService = masterDataService;
        }

        [HttpPost("[action]")]
        public IActionResult MasterDataGetListByGroupCode([FromBody]MasterDataEntity _object)
        {
            DataTable result = _masterDataService.GetListByGroupCode(_object.GroupCode);

            return Ok(result);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Service.IService
{
    public interface IMasterDataService
    {
        DataTable GetListByGroupCode(string GroupCode);
        int Insert(string GroupCode, string Code, string Name, int? Order);
    }
}

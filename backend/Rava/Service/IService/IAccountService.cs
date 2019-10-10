using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Service.IService
{
    public interface IAccountService
    {
        DataTable GetAccount(string phone);
    }
}

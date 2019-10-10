using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Services.IService
{
    public interface IAccountService
    {
        DataTable GetAccount(string phone);
    }
}

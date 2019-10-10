using System;
using System.Collections.Generic;
using System.Text;

namespace Service.IService
{
    public interface IUtitlitiesService
    {
        string CreateNewCode(string TableName, string ColumnName);
    }
}

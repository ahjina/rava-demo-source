﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Services.IService
{
    public interface IUtitlitiesService
    {
        string CreateNewCode(string TableName, string ColumnName);
    }
}

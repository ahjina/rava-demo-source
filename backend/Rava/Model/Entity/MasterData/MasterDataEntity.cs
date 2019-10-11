using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entity.MasterData
{
    public class MasterDataEntity
    {
        public string GroupCode { get; set; }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Order { get; set; }
    }
}

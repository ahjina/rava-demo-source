using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Product
{
    public class AttributeDetailEntity
    {
        public string ProductCode { get; set; }
        public string AttributeCode { get; set; }
        public string Value { get; set; }
    }
}

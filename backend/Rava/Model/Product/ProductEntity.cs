using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Product
{
    public class ProductEntity
    {
        [Key]
        public string ProductCode { get; set; }
        public string Name { get; set; }

        public int? Type { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int Status { get; set; }
    }
}

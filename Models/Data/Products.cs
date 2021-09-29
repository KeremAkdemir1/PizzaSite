using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VatanBilgisayar.Models.Data
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductPhoto { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public string AddingDate { get; set; }
    }
}

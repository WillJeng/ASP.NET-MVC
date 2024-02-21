using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService.Models
{
    public class ProductDisplayModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int? DiscountPrice { get; set; }
        public string Description { get; set; }
        public int StockCount { get; set; }
        public string? ImagePath { get; set; }
    }
}

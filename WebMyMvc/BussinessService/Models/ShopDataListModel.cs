using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService.Models
{
    public class ShopDataListModel
    {
        public Guid Id { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? CourseId { get; set; }
        public string ProductName { get; set; }
        public string CourseName { get;set; }
        public int Quantity { get; set; }
        public int TotalAmount { get; set; }

        public string? ProImagePath { get; set; }
        public string? CouImagePath { get; set; }
    }
}

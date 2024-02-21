using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService.Models
{
    public class ShopDataModel
    {
        public Guid Id { get; set; }
        public Guid MemberAccountId { get; set; }
        public Guid? CourseDisplayId { get; set; }
        public Guid? ProductDisplayId { get; set; }
        public int Quantity { get; set; }
        public int TotalAmount { get; set; }
    }
}

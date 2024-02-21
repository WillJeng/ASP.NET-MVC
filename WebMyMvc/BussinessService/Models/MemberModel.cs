using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService.Models
{
    public class MemberModel
    {
        public Guid id { get; set; }
        public String username { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public String? phone { get; set; }
        public DateTime? initdate { get; set; }
        public DateTime? modifydate { get; set; }
    }
}

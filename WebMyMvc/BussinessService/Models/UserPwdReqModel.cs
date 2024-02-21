using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService.Models
{
    public class UserPwdReqModel
    {
        public Guid Id { get; set; }
        public string NewPwd { get; set; }
        public string OldPwd { get; set; }
    }
}

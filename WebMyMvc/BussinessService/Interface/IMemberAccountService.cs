using BussinessService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService.Interface
{
    public interface IMemberAccountService
    {
        Task<bool> UserRegisterAsync(MemberModel mem);
        Task<bool> UserPwdUpdateAsync(UserPwdReqModel userPwdReqModel);
        Task<bool> UserDataUpdataAsync(UserDataReqModel userDataReqModel);
        Task<bool> UserForgetPwdAsync(UserForgetPwdModel userForgetPwdModel);
    }
}

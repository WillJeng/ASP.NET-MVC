using BussinessService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService.Interface
{
    public interface IMemberAccountRepository
    {
        Task<MemberModel> QueryByEamilAsync(string email);

        Task<bool> UpdateDataAsync(UserDataReqModel userDataReqModel);
        Task<bool> CreateAsync(MemberModel memberModel);
        Task<bool> UpdatePwdAsync(Guid userId, string newPwd);
        Task<MemberModel> QueryByIdAsync(Guid id);
        Task<UserForgetPwdModel> QueryByNameAsync(string name, string email);
    }
}

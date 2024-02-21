using BussinessService.Interface;
using BussinessService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService.Service
{
    public class LoginService : ILoginService
    {
        //把會員帳號信箱的介面導入
        private readonly IMemberAccountRepository _memberAccountRepository;
        public LoginService(IMemberAccountRepository memberAccountRepository) 
        {
            _memberAccountRepository = memberAccountRepository;
        }
        public async Task<MemberModel> UserSignAsync(string email, string pwd)
        {
            //非同步判斷會員帳號信箱是否取到值
            var user = await _memberAccountRepository.QueryByEamilAsync(email);
            if(user == null) 
            {
                return null;
            }

            //非同步判斷會員密碼信箱是否取到值
            var hashPwd = PwdService.PwdSHA256Hash(pwd, user.id.ToString());

            if (hashPwd != user.password)
            {
                return null;
            }

            return user;
        }
    }
}

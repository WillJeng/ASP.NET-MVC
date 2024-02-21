using BussinessService.Interface;
using BussinessService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService.Service
{
    public class MemberAccountService : IMemberAccountService
    {
        //導入資料庫介面 讀取帳戶Email與ID的抓取結果
        private IMemberAccountRepository _memberAccountRepository;
        public MemberAccountService(IMemberAccountRepository memberAccountRepository) 
        {
            _memberAccountRepository = memberAccountRepository;
        }

        //更新會員資料介面
        public async Task<bool> UserDataUpdataAsync(UserDataReqModel userDataReqModel )
        {
            var data = await _memberAccountRepository.QueryByIdAsync(userDataReqModel.Id);

            if (data == null)
            { 
                return false;
            }

            await _memberAccountRepository.UpdateDataAsync(userDataReqModel);
            return true;
        }

        //忘記密碼介面
        public async Task<bool> UserForgetPwdAsync(UserForgetPwdModel userForgetPwdModel)
        {
            var userName = await _memberAccountRepository.QueryByNameAsync(userForgetPwdModel.UserName, userForgetPwdModel.Email);

            if (userName == null)
            {
                return false;
            }

            var newHashPwd = PwdService.PwdSHA256Hash("12345678", userName.Id.ToString());
            await _memberAccountRepository.UpdatePwdAsync(userName.Id, newHashPwd);

            return true;
        }

        //更改密碼介面
        public async Task<bool> UserPwdUpdateAsync(UserPwdReqModel userPwdReqModel)
        {
            var mem = await _memberAccountRepository.QueryByIdAsync(userPwdReqModel.Id);

            if(mem == null)
            {
                return false;
            }

            //檢查舊密碼是否正確
            var oldHashPwd = PwdService.PwdSHA256Hash(userPwdReqModel.OldPwd, userPwdReqModel.Id.ToString());

            if (oldHashPwd != mem.password)
            {
                return false;
            }

            //呼叫更新密碼的method 進行更新
            var newHashPwd = PwdService.PwdSHA256Hash(userPwdReqModel.NewPwd, userPwdReqModel.Id.ToString());
            await _memberAccountRepository.UpdatePwdAsync(userPwdReqModel.Id, newHashPwd);

            return true;
        }

        //註冊帳號介面
        public async Task<bool> UserRegisterAsync(MemberModel mem)
        {
            //檢查是否重複
            var user = await _memberAccountRepository.QueryByEamilAsync(mem.email);
            if (user != null)
            {
                return false;
            }
            mem.id = Guid.NewGuid();
            mem.initdate = DateTime.Now;
            mem.password = PwdService.PwdSHA256Hash(mem.password, mem.id.ToString());

            return await _memberAccountRepository.CreateAsync(mem);
        }

    }
}

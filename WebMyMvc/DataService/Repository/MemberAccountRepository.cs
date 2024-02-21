using BussinessService.Interface;
using BussinessService.Models;
using DataService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repository
{
    public class MemberAccountRepository : IMemberAccountRepository
    {
        private angelprojectContext _dbcontext;

        public MemberAccountRepository(angelprojectContext dbcontext) 
        {
            _dbcontext = dbcontext;
        }

        //創建帳戶
        public async Task<bool> CreateAsync(MemberModel memberModel)
        {

            await _dbcontext.MemberAccount.AddAsync(new MemberAccount()
            { 
                Id = memberModel.id,
                Username = memberModel.username,
                Email = memberModel.email,
                Password = memberModel.password,
                Phone = memberModel.phone,
                Initdate = memberModel.initdate,
                Modifydate = memberModel.modifydate
            });

            //保存最後更改到數據庫
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        //查詢會員Email是否確
        public async Task<MemberModel> QueryByEamilAsync(string email)
        {
           var mem = await _dbcontext.MemberAccount.Where(x => x.Email.ToUpper() == email.ToUpper()).FirstOrDefaultAsync();
            if (mem == null)
            {
                return null;
            }
            return new MemberModel()
            {
                id = mem.Id,
                username = mem.Username,
                email = mem.Email,
                password = mem.Password,
                phone = mem.Phone,
                initdate = mem.Initdate,
                modifydate = mem.Modifydate
            };
        }

        //查詢會員Id是否正確
        public async Task<MemberModel> QueryByIdAsync(Guid id)
        {
            var mem = await _dbcontext.MemberAccount.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (mem == null)
            {
                return null;
            }

            return new MemberModel()
            {
                id = mem.Id,
                username = mem.Username,
                email = mem.Email,
                password = mem.Password,
                phone = mem.Phone,
                initdate = mem.Initdate,
                modifydate = mem.Modifydate
            };
        }

        //更新會員資料
        public async Task<bool> UpdateDataAsync(UserDataReqModel userDataReqModel)
        {
            var entity = await _dbcontext.MemberAccount.FindAsync(userDataReqModel.Id);
            if(entity != null) 
            {
                entity.Username = userDataReqModel.UserName;
                entity.Email = userDataReqModel.Email;
                entity.Phone = userDataReqModel.Phone;
                entity.Modifydate = DateTime.Now;
            };

            //保存最後更改到數據庫
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        //用Id作為Where條件 將更改成新密碼
        public async Task<bool> UpdatePwdAsync(Guid userId, string newPwd)
        {
            var entity = await _dbcontext.MemberAccount.Where(u => u.Id == userId).FirstOrDefaultAsync();

            if (entity == null)
            { 
                return false;
            }

            entity.Password = newPwd;
            await _dbcontext.SaveChangesAsync();

            return true;
        }

        //利用Email查詢會員Name是否正確
        public async Task<UserForgetPwdModel> QueryByNameAsync(string name, string email)
        {
            var mem = await _dbcontext.MemberAccount.Where(x => x.Username.ToUpper() == name.ToUpper() && x.Email.ToUpper() == email.ToUpper()).FirstOrDefaultAsync();

            if (mem == null)
            {
                return null;
            }

            return new UserForgetPwdModel()
            {
                Id = mem.Id,
                UserName = mem.Username,
                Email = mem.Email
            };
        }
    }
}

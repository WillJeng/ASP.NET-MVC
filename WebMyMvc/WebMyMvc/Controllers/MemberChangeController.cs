using BussinessService.Interface;
using MessagePack.Formatters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebMyMvc.Models.ViewModels;
using BussinessService.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using System.ComponentModel.DataAnnotations;

namespace WebMyMvc.Controllers
{
    public class MemberChangeController : Controller
    {
        private IMemberAccountService _memberAccountService;
        public MemberChangeController(IMemberAccountService memberAccountService)
        { 
            _memberAccountService = memberAccountService;
        }
        public IActionResult ChangePwd()
        {
            return View();
        }

        public IActionResult ChangeData()
        {
            return View();
        }

        //更改密碼
        public async Task<IActionResult> MemberChangePwd(UserChangePwdModel userChangePwdModel) 
        {
            if (userChangePwdModel.NewPwd != userChangePwdModel.ConfirmNewPwd)
            {
                ViewBag.Message = "新密碼不一致";
                return View("ChangePwd");
            }

            //利用ClaimTypes.NameIdentifier 去找身分驗證系統的唯一ID值
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _memberAccountService.UserPwdUpdateAsync(new UserPwdReqModel()
            {
                Id = Guid.Parse(userId),
                NewPwd = userChangePwdModel.NewPwd,
                OldPwd = userChangePwdModel.OldPwd,
            });

            if (!result)
            {
                ViewBag.Message = "密碼更新失敗";
                return View("ChangePwd");
            }

            ViewBag.Success = true;
            //return RedirectToAction("Logout", "Login");
            return View("ChangePwd");
        }


        //修改會員資料
        public async Task<IActionResult> MemberChangeData(UserChangeDataModel userChangeDataModel)
        {
            //偵測模組狀態
            if (ModelState.IsValid)
            {

                //利用ClaimTypes.NameIdentifier 去找身分驗證系統的唯一ID值
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


                //帳號Id是否正確與資料庫寫入的結果
                await _memberAccountService.UserDataUpdataAsync(new UserDataReqModel()
                {
                    Id = Guid.Parse(userId),
                    UserName = userChangeDataModel.UserName,
                    Email = userChangeDataModel.Email,
                    Phone = userChangeDataModel.Phone,
                });

                ViewBag.Success = true;
                return View("ChangeData");
            }

            return View("ChangeData", userChangeDataModel);
        }
    }
}

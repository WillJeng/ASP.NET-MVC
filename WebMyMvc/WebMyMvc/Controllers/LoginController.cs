using BussinessService.Interface;
using BussinessService.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebMyMvc.Models.ViewModels;

namespace WebMyMvc.Controllers
{
    public class LoginController : Controller
    {
        //導入會員登入介面
        private ILoginService _loginService;
        private IMemberAccountService _memberAccountService;
        public LoginController(ILoginService loginService, IMemberAccountService memberAccountService) 
        {
            _loginService = loginService;
            _memberAccountService = memberAccountService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserRegister() 
        {
            return View();
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        //會員登入的Action
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(UserLoginViewModel model) 
        {
            //偵測模組狀態
            if (ModelState.IsValid)
            {
                //導入UserSignAsync方法取出的結果 作判斷
                var mem = await _loginService.UserSignAsync(model.Email, model.Pwd);
                if (mem == null)
                {
                    ViewBag.Message = "登入失敗，請重新登入";
                    return View("Index", model);
                }

                //用來做身分驗證和授權機制 登入後將資訊保存在cookie
                if (mem.phone != null)//判斷電話是否為null值
                {
                    Claim[] claims = new[]
                    {
                    new Claim(ClaimTypes.Name, mem.username),
                    new Claim(ClaimTypes.NameIdentifier, mem.id.ToString()),
                    new Claim(ClaimTypes.Email, mem.email),
                    new Claim(ClaimTypes.MobilePhone, mem.phone),
                    };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    //執行登入
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsPrincipal));
                }
                else {
                    Claim[] claims = new[]
{
                    new Claim(ClaimTypes.Name, mem.username),
                    new Claim(ClaimTypes.NameIdentifier, mem.id.ToString()),
                    new Claim(ClaimTypes.Email, mem.email)
                    };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    //執行登入
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsPrincipal));
                }

                ViewBag.Success = true;
                return View("Index");  
            }


            ViewBag.Message = "登入失敗，請重新登入";
            return View("Index", model);

        }

        //會員註冊的Action
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterModel userRegisterModel)
        {
            //偵測模組狀態
            if (ModelState.IsValid)
            {
                if (userRegisterModel.Password != userRegisterModel.ComfirmPassword)
                {
                    //二次密碼不相同
                    ViewBag.Message = "二次密碼不一致";
                    return View("UserRegister", userRegisterModel);
                }

                //檢查帳號是否重複與資料庫寫入的結果
                var result = await _memberAccountService.UserRegisterAsync(new MemberModel()
                { 
                    username = userRegisterModel.UserName,
                    phone = userRegisterModel.Phone,
                    email = userRegisterModel.Email,
                    password = userRegisterModel.Password,
                });
                //檢查帳號是否重複
                if (!result)
                {
                    ViewBag.Message = "帳號重複";
                    return View("UserRegister", userRegisterModel);
                }

                ViewBag.Success = true;
                return View("UserRegister");

            }
            return View("UserRegister", userRegisterModel);
        }

        //忘記密碼的Action
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Password(UserForgetPasswordModel userForgetPasswordModel)
        {
            //偵測模組狀態
            if (ModelState.IsValid)
            {
                //利用ClaimTypes.NameIdentifier 去找身分驗證系統的唯一ID值
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var result = await _memberAccountService.UserForgetPwdAsync(new UserForgetPwdModel()
                {
                    UserName = userForgetPasswordModel.UserName,
                    Email = userForgetPasswordModel.Email
                });

                if (!result)
                {
                    ViewBag.Message = "資料不正確 請重新填寫";
                    return View("ForgetPassword");
                }

                ViewBag.Success = true;
                return View("ForgetPassword");
            }

            return View("ForgetPassword", userForgetPasswordModel);
        }

        //會員登出
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}

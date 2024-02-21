using System.ComponentModel.DataAnnotations;

namespace WebMyMvc.Models.ViewModels
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "請輸入Email作為登入帳號")]
        [Display(Name = "電子信箱")]
        public string Email { get; set; }

        [Required(ErrorMessage = "請輸入密碼")]
        [Display(Name = "密碼")]
        public string Pwd { get; set; }
    }
}

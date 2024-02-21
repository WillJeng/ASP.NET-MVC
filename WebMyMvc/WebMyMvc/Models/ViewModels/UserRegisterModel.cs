using System.ComponentModel.DataAnnotations;

namespace WebMyMvc.Models.ViewModels
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage = "請輸入姓名")]
        [Display(Name = "姓名")]
        public string UserName { get; set; }
        [Display(Name = "電話")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "請輸入信箱 作為登入帳號")]
        [Display(Name = "電子信箱")]
        public string Email { get; set; }
        [Required(ErrorMessage = "請輸入密碼")]
        [Display(Name = "密碼")]
        public string Password { get; set; }
        [Required(ErrorMessage = "請再次輸入密碼")]
        [Display(Name = "二次密碼")]
        public string ComfirmPassword { get; set; }
    }
}

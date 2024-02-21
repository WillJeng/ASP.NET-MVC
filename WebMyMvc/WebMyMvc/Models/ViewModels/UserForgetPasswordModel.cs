using System.ComponentModel.DataAnnotations;

namespace WebMyMvc.Models.ViewModels
{
    public class UserForgetPasswordModel
    {
        [Required(ErrorMessage = "請輸入會員姓名")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "請輸入會員信箱(帳號)")]
        public string Email { get; set; }

    }
}

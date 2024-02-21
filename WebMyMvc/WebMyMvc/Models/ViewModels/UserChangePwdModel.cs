using System.ComponentModel.DataAnnotations;

namespace WebMyMvc.Models.ViewModels
{
    public class UserChangePwdModel
    {
        [Required(ErrorMessage = "請輸入舊密碼")]
        public string OldPwd { get; set; }
        [Required(ErrorMessage = "請輸入新密碼")]
        public string NewPwd { get; set; }
        [Required(ErrorMessage = "請再次輸入新密碼")]
        public string ConfirmNewPwd { get; set; }
    }
}

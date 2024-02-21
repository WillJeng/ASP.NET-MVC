using Azure.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebMyMvc.Models.ViewModels
{
    public class UserChangeDataModel
    {
        [Required(ErrorMessage = "請輸入修改的姓名")]
        public string UserName {get;set;}
        [Required(ErrorMessage = "請輸入修改的電話")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "請輸入修改的信箱")]
        public string Email { get; set; }
        
    }
}

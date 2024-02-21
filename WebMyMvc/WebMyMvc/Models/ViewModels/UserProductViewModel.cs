using System.ComponentModel.DataAnnotations;

namespace WebMyMvc.Models.ViewModels
{
    public class UserProductViewModel
    {
        [Required(ErrorMessage = "Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "編號")]
        [Display(Name = "編號")]
        public string Code { get; set; }

        [Required(ErrorMessage = "產品名稱")]
        [Display(Name = "產品名稱")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "價格")]
        [Display(Name = "價格")]
        public int Price { get; set; }

        [Required(ErrorMessage = "優惠價格")]
        [Display(Name = "優惠價格")]
        public int? DiscountPrice { get; set; }

        [Required(ErrorMessage = "商品描述")]
        [Display(Name = "商品描述")]
        public string? Description { get; set; }


        [Required(ErrorMessage = "庫存數量")]
        [Display(Name = "庫存數量")]
        public int StockCount { get; set; }

        [Required(ErrorMessage = "圖片路徑")]
        [Display(Name = "圖片路徑")]
        public string? ImagePath { get; set; }
    }
}

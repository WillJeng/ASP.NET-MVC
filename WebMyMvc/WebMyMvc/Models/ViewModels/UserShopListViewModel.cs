namespace WebMyMvc.Models.ViewModels
{
    public class UserShopListViewModel
    {
        public Guid Id { get; set; }
        public Guid MemberAccountId { get; set; }
        public Guid? CourseDisplayId { get; set; }
        public Guid? ProductDisplayId { get; set; }
        public int Quantity { get; set; }
        public int TotalAmount { get; set; }
    }
}

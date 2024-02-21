using BussinessService.Interface;
using Microsoft.AspNetCore.Mvc;
using WebMyMvc.Models.ViewModels;

namespace WebMyMvc.Controllers
{
    public class ProductDisplayController : Controller
    {
        private readonly IProductDisplayService _productDisplayService;

        public ProductDisplayController(IProductDisplayService productDisplayService) 
        {
            _productDisplayService = productDisplayService;
        }
        public async Task<ActionResult> Index(string category)
        {
            var userProductViewModel = await _productDisplayService.QueryAsync(category);
            var vm = new List<UserProductViewModel>();

            foreach (var item in userProductViewModel)
            {
                var userProductViewModels = new UserProductViewModel
                {
                    Id = item.Id,
                    Code = item.Code,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    DiscountPrice = item.DiscountPrice,
                    Description = item.Description,
                    ImagePath = item.ImagePath,
                };

                vm.Add(userProductViewModels);
            }

            return View(vm);
        }
    }
}

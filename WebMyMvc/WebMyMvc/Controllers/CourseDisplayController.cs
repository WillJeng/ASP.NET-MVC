using BussinessService.Interface;
using Microsoft.AspNetCore.Mvc;
using WebMyMvc.Models.ViewModels;

namespace WebMyMvc.Controllers
{
    public class CourseDisplayController : Controller
    {
        private readonly ICourseDisplayService _courseDisplayService;

        public CourseDisplayController(ICourseDisplayService courseDisplayService) 
        {
            _courseDisplayService = courseDisplayService;
        }
        public async Task<IActionResult> Index(string category)
        {
            var userCourseViewModel = await _courseDisplayService.QueryAsync(category);
            var vm = new List<UserCourseViewModel>();
            foreach (var item in userCourseViewModel)
            {
                var userCourseViewModels = new UserCourseViewModel
                {
                    Id = item.Id,
                    Code = item.Code,
                    CourseName = item.CourseName,
                    Price = item.Price,
                    DiscountPrice = item.DiscountPrice,
                    Description = item.Description,
                    Sdate = item.Sdate,
                    Edate = item.Edate,
                    Locations = item.Locations,
                    ImagePath = item.ImagePath,
                };
                vm.Add(userCourseViewModels);
            }

            return View(vm);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace WebMyMvc.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

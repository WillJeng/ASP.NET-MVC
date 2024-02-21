using BussinessService.Interface;
using BussinessService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WebMyMvc.Controllers
{
    public class ShopListController : Controller
    {
        private IShopService _shopService;

        public ShopListController(IShopService shopService)
        {
            _shopService = shopService;
        }


        [Authorize]
        public async Task<IActionResult> ProShopList()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var viewModel = await _shopService.BookingProListAsync(Guid.Parse(userId));
            return View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> CouShopList()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var viewModel = await _shopService.BookingCouListAsync(Guid.Parse(userId));
            return View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> ShopOrderList()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var viewModel = await _shopService.BookingShopListAsync(Guid.Parse(userId));
            return View(viewModel);
        }

        public async Task<IActionResult> ShopOrderData()
        { 
            return View();
        }

        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ShopCar(string productId, string courseId, int quantity, int totalAmount)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (productId == null)
            {
                var couId = Guid.Parse(courseId);
                var result = await _shopService.BookingShopAsync(null, couId, new ShopDataModel()
                {
                    MemberAccountId = Guid.Parse(userId),
                    ProductDisplayId = null,
                    CourseDisplayId = Guid.Parse(courseId),
                    Quantity = quantity,
                    TotalAmount = totalAmount
                });
                if (!result)
                {
                    TempData["ShopCar"] = "需要的庫存不足 請重新整理確認";
                    return View("Index");
                }

                ViewBag.Success = true;
                return View("~/Views/CourseDisplay/Index.cshtml");
            }
            else if (courseId == null)
            {
                var proId = Guid.Parse(productId);
                var result = await _shopService.BookingShopAsync(proId, null, new ShopDataModel()
                {
                    MemberAccountId = Guid.Parse(userId),
                    ProductDisplayId = Guid.Parse(productId),
                    CourseDisplayId = null,
                    Quantity = quantity,
                    TotalAmount = totalAmount
                });
                if (!result)
                {
                    TempData["ShopCar"] = "需要的庫存不足 請重新整理確認";
                    return View("Index");
                }

                ViewBag.Success = true;
                return View("~/Views/ProductDisplay/Index.cshtml");
            }

            ViewBag.Success = true;
            return View("index");
        }

        public async Task<IActionResult> DelBooking(string proShopId, string couShopId)
        {
            if (proShopId != null)
            {
                var result = await _shopService.DelBookingShopListAsync(Guid.Parse(proShopId));
                if (!result)
                {
                    ViewBag.Message = "刪除失敗";
                    return RedirectToAction("ProShopList", "ShopList");
                }

                ViewBag.Success = true;
                return View("ProShopList");
            }
            else
            {
                var result = await _shopService.DelBookingShopListAsync(Guid.Parse(couShopId));
                if (!result)
                {
                    ViewBag.Message = "刪除失敗";
                    return RedirectToAction("CouShopList", "ShopList");
                }

                ViewBag.Success = true;
                return View("CouShopList");
            }

        }
    }
}

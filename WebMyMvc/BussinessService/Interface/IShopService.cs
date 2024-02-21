using BussinessService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService.Interface
{
    public interface IShopService
    {
        Task<bool> BookingShopAsync(Guid? productId, Guid? courseId, ShopDataModel shopData);

        Task<List<ShopDataListModel>> BookingProListAsync(Guid userId);

        Task<List<ShopDataListModel>> BookingCouListAsync(Guid userId);
        Task<List<ShopDataListModel>> BookingShopListAsync(Guid userId);

        Task<bool> DelBookingShopListAsync(Guid shopListId);
    }
}

using BussinessService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService.Interface
{
    public interface IShopRepository
    {
        Task<bool> AddScheduleAsync(ShopDataModel shopDataModel);
        Task<ProductDisplayModel> GetStockAsync(Guid? productId);
        Task<CourseDisplayModel> GeyPeopleAsync(Guid? courseId);

        Task<List<ShopDataListModel>> GetShopListAsync(Guid userId);

        Task<bool> DelShopAsync(Guid shopListId);
    }
}

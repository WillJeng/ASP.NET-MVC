using BussinessService.Interface;
using BussinessService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService.Service
{
    public class ShopService:IShopService
    {
        private readonly IShopRepository _shopRepository;
        public ShopService(IShopRepository shopRepository) 
        {
            _shopRepository = shopRepository;
        }

        //客戶購物車課程清單介面
        public async Task<List<ShopDataListModel>> BookingCouListAsync(Guid userId)
        {
            var list = await _shopRepository.GetShopListAsync(userId);
            var couList = list.Where(item => item.CourseId!= null).ToList();

            return couList;
        }


        //客戶購物車產品清單介面
        public async Task<List<ShopDataListModel>> BookingProListAsync(Guid userId)
        {
            var list = await _shopRepository.GetShopListAsync(userId);
            var proList = list.Where(item => item.ProductId != null).ToList();

            return proList;
            
        }


        //購物車結帳介面
        public async Task<List<ShopDataListModel>> BookingShopListAsync(Guid userId)
        {
            var list = await _shopRepository.GetShopListAsync(userId);
            return list;
        }


        //加入購物清單功能介面
        public async Task<bool> BookingShopAsync(Guid? dataId, Guid? couId, ShopDataModel shopData)
        {
            if (dataId != null)
            {
                //判斷產品庫存是否足夠
                var stock = await _shopRepository.GetStockAsync(dataId);
                if (stock.StockCount < shopData.Quantity)
                {
                    return false;
                }
            }
            else if (couId != null)
            {
                //判斷人數是否已額滿
                var people = await _shopRepository.GeyPeopleAsync(couId);
                if (people.RemainingPlaces < shopData.Quantity)
                {
                    return false;
                }
            }
            return await _shopRepository.AddScheduleAsync(shopData);
        }


        //刪除單筆購物清單的介面
        public async Task<bool> DelBookingShopListAsync(Guid shopListId)
        {
            return await _shopRepository.DelShopAsync(shopListId);
        }
    }
}

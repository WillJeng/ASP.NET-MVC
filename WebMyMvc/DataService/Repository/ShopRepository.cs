using BussinessService.Interface;
using BussinessService.Models;
using DataService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repository
{
    public class ShopRepository:IShopRepository
    {
        private angelprojectContext _dbcontext;

        public ShopRepository(angelprojectContext dbcontext)
        { 
            _dbcontext = dbcontext;
        }

        //新增購物車清單ID
        public async Task<bool> AddScheduleAsync(ShopDataModel shopDataModel)
        {
            var entity = new ShoppingList()
            {
                Id = Guid.NewGuid(),
                MemberAccountId = shopDataModel.MemberAccountId,
                CourseDisplayId = shopDataModel.CourseDisplayId,
                ProductDisplayId = shopDataModel.ProductDisplayId,
                Quantity = shopDataModel.Quantity,
                TotalAmount = shopDataModel.TotalAmount
            };

            await _dbcontext.ShoppingList.AddAsync(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        //刪除購物清單ID
        public async Task<bool> DelShopAsync(Guid shopListId)
        {
            var entity = await _dbcontext.ShoppingList.Where(x => x.Id == shopListId).FirstOrDefaultAsync();
            if (entity != null)
            { 
                _dbcontext.ShoppingList.Remove(entity);
            }
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        //用會員ID取購物清單資料
        public async Task<List<ShopDataListModel>> GetShopListAsync(Guid userId)
        {
            var query = from shoplist in _dbcontext.ShoppingList
                        join p in _dbcontext.ProductDisplay on shoplist.ProductDisplayId equals p.Id into productJoin
                        from product in productJoin.DefaultIfEmpty()
                        join c in _dbcontext.CourseDisplay on shoplist.CourseDisplayId equals c.Id into courseJoin
                        from course in courseJoin.DefaultIfEmpty()
                        where shoplist.MemberAccountId == userId
                        select new ShopDataListModel
                        {
                            Id = shoplist.Id,
                            ProductId = shoplist.ProductDisplayId,
                            CourseId = shoplist.CourseDisplayId,
                            ProductName = product != null ? product.ProductName : null,
                            CourseName = course != null ? course.CourseName : null,
                            Quantity = shoplist.Quantity,
                            TotalAmount = shoplist.TotalAmount,
                            ProImagePath = product.ImagePath,
                            CouImagePath = course.ImagePath,
                        };
            return await query.ToListAsync();
        }

        //用產品ID查詢此筆資料
        public async Task<ProductDisplayModel> GetStockAsync(Guid? productId)
        {
            var pro = await _dbcontext.ProductDisplay.Where(x => x.Id == productId).FirstOrDefaultAsync();
            if (pro == null)
            {
                return null;
            }
            return new ProductDisplayModel()
            {
                Id = pro.Id,
                ProductName = pro.ProductName,
                Price = pro.Price,
                DiscountPrice = pro.DiscountPrice,
                Description = pro.Description,
                StockCount = pro.StockCount
            };
        }

        //用課程ID查詢此筆資料
        public async Task<CourseDisplayModel> GeyPeopleAsync(Guid? courseId)
        {
            var cou = await _dbcontext.CourseDisplay.Where(x => x.Id == courseId).FirstOrDefaultAsync();
            if (cou == null)
            {
                return null;
            }
            return new CourseDisplayModel()
            {
                Id = cou.Id,
                Code = cou.Code,
                CourseName = cou.CourseName,
                Price = cou.Price,
                DiscountPrice = cou.DiscountPrice,
                Description = cou.Description,
                Sdate = cou.Sdate,
                Edate = cou.Edate,
                Locations = cou.Locations,
                RemainingPlaces = cou.RemainingPlaces
            };
        }
    }
}

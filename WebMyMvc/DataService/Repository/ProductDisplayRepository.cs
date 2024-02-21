using BussinessService.Interface;
using BussinessService.Models;
using DataService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repository
{
    public class ProductDisplayRepository : IProductDisplayRepository
    {
        private readonly angelprojectContext _dbcontext;

        public ProductDisplayRepository(angelprojectContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        //
        public async Task<IEnumerable<ProductDisplayModel>> QueryAsync(string category)
        {
            var query = from pd in _dbcontext.ProductDisplay
                        where pd.Code.StartsWith(category) || string.IsNullOrEmpty(category)
                        orderby pd.Code ascending
                        select new ProductDisplayModel
                        {
                            Id = pd.Id,
                            Code = pd.Code,
                            ProductName = pd.ProductName,
                            Price = (int)pd.Price,
                            DiscountPrice = (int)pd.DiscountPrice,
                            Description = pd.Description,
                            ImagePath = pd.ImagePath,
                        };
            return await query.ToListAsync();
        }
    }
}

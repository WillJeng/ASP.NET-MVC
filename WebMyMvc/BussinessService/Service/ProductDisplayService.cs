using BussinessService.Interface;
using BussinessService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService.Service
{
    public class ProductDisplayService:IProductDisplayService
    {
        private readonly IProductDisplayRepository _productDisplayRepository;

        public ProductDisplayService(IProductDisplayRepository productDisplayRepository)
        {
            _productDisplayRepository = productDisplayRepository;
        }

        public async Task<List<ProductDisplayModel>> QueryAsync(string category)
        {
            var productDisplayModel = await _productDisplayRepository.QueryAsync(category);
            return productDisplayModel.ToList();
        }
    }
}

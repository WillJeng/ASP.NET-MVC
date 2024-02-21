using BussinessService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService.Interface
{
    public interface IProductDisplayService
    {
        public Task<List<ProductDisplayModel>> QueryAsync(string category);
    }
}

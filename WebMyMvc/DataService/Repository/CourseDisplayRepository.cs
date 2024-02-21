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
    public class CourseDisplayRepository:ICourseDisplayRepository
    {
        private readonly angelprojectContext _dbcontext;
        public CourseDisplayRepository(angelprojectContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<CourseDisplayModel>> QueryAsync(string category)
        {
            var query = from cd in _dbcontext.CourseDisplay
                        where cd.Code.StartsWith(category) || string.IsNullOrEmpty(category)
                        orderby cd.Code ascending
                        select new CourseDisplayModel
                        {
                            Id = cd.Id,
                            Code = cd.Code,
                            CourseName = cd.CourseName,
                            Price = (int)cd.Price,
                            DiscountPrice = (int)cd.DiscountPrice,
                            Description = cd.Description,
                            Sdate = (DateTime)cd.Sdate,
                            Edate = (DateTime)cd.Edate,
                            Locations = cd.Locations,
                            RemainingPlaces = cd.RemainingPlaces,
                            ImagePath = cd.ImagePath,
                        };
            return await query.ToListAsync();
        }
    }
}

using BussinessService.Interface;
using BussinessService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService.Service
{
    public class CourseDisplayService:ICourseDisplayService
    {
        private ICourseDisplayRepository _courseDisplayRepository;
        public CourseDisplayService(ICourseDisplayRepository courseDisplayRepository) 
        {
            _courseDisplayRepository = courseDisplayRepository; 
        }

        public async Task<List<CourseDisplayModel>> QueryAsync(string category)
        {
            var courseDisplayModel = await _courseDisplayRepository.QueryAsync(category);
            return courseDisplayModel.ToList();
        }
    }
}

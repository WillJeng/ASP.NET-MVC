﻿using BussinessService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService.Interface
{
    public interface ICourseDisplayService
    {
        Task<List<CourseDisplayModel>> QueryAsync(string category);
    }
}

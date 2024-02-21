﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService.Models
{
    public class CourseDisplayModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string CourseName { get; set; }
        public int Price { get; set; }
        public int? DiscountPrice { get; set; }
        public string? Description { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public string? Locations { get; set; }
        public int? RemainingPlaces{get;set;}
        public string? ImagePath { get; set; }
    }
}

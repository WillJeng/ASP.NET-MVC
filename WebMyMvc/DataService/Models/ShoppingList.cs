﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DataService.Models;

public partial class ShoppingList
{
    public Guid Id { get; set; }

    public Guid MemberAccountId { get; set; }

    public Guid? CourseDisplayId { get; set; }

    public Guid? ProductDisplayId { get; set; }

    public int Quantity { get; set; }

    public int TotalAmount { get; set; }
}
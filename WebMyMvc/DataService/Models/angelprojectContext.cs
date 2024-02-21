﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataService.Models;

public partial class angelprojectContext : DbContext
{
    public angelprojectContext(DbContextOptions<angelprojectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CourseDisplay> CourseDisplay { get; set; }

    public virtual DbSet<MemberAccount> MemberAccount { get; set; }

    public virtual DbSet<ProductDisplay> ProductDisplay { get; set; }

    public virtual DbSet<ShoppingList> ShoppingList { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourseDisplay>(entity =>
        {
            entity.ToTable("CourseDisplay");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.CourseName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Edate).HasColumnType("date");
            entity.Property(e => e.Locations)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sdate).HasColumnType("date");
        });

        modelBuilder.Entity<MemberAccount>(entity =>
        {
            entity.ToTable("MemberAccount");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Initdate)
                .HasColumnType("datetime")
                .HasColumnName("initdate");
            entity.Property(e => e.Modifydate)
                .HasColumnType("datetime")
                .HasColumnName("modifydate");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<ProductDisplay>(entity =>
        {
            entity.ToTable("ProductDisplay");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ShoppingList>(entity =>
        {
            entity.ToTable("ShoppingList");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
using BussinessService.Interface;
using BussinessService.Service;
using DataService.Models;
using DataService.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//���U Entity Framework Core ����Ʈw���e
builder.Services.AddDbContext<angelprojectContext>(
    options => options.UseSqlServer("name=ConnectionStrings:KhNetCourseDB"));
// Add services to the container.

builder.Services.AddControllersWithViews();

//���U����
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IMemberAccountRepository, MemberAccountRepository>();
builder.Services.AddScoped<IMemberAccountService, MemberAccountService>();
builder.Services.AddScoped<IProductDisplayRepository, ProductDisplayRepository>();
builder.Services.AddScoped<IProductDisplayService, ProductDisplayService>();
builder.Services.AddScoped<ICourseDisplayService, CourseDisplayService>();
builder.Services.AddScoped<ICourseDisplayRepository, CourseDisplayRepository>();
builder.Services.AddScoped<IShopService, ShopService>();
builder.Services.AddScoped<IShopRepository, ShopRepository>();


//���UCookie�n�J���ҳB�z�{��
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
        option => { 
            
        });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();//Cookie  login��������
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using FluentValidation;
using FluentValidation.AspNetCore;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess.Data;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using MVC_apple_store.Interfaces;
using MVC_apple_store.Services;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("LocalDb");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreDbContext>(x =>
        x.UseSqlServer(connectionString));

// repository 
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// services
builder.Services.AddScoped<IPhoneService, PhoneService>();
builder.Services.AddScoped<ICartService, CartService>();

// auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// fluent validators
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

// session configurations
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddHttpContextAccessor();

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

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

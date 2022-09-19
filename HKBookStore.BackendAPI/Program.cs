using FluentAssertions.Common;
using HKBookStore.Application.Catalog.Products;
using HKBookStore.Data.EF;
using HKBookStore.Utilities.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HKBookStoreDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString(SystemConstants.MainConnectionString)));

//Declare DI

builder.Services.AddTransient<IPublicProductService, PublicProductService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger HK BookStore", Version = "v1" });
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

app.UseAuthorization();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger HKBookStore V1");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

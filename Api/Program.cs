using Application.Services;
using Application.Services.Contracts;
using Domain.Services;
using Domain.Services.Contracts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning();
builder.Services.AddSwaggerGen();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddDbContext<InventoryDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("StoreDatabase"))
);

// User
builder.Services.AddScoped<IUserApplication, UserApplication>();
builder.Services.AddScoped<IUserDomain, UserDomain>();

// Brand
builder.Services.AddScoped<IBrandApplication, BrandApplication>();
builder.Services.AddScoped<IBrandDomain, BrandDomain>();

// Category
builder.Services.AddScoped<ICategoryApplication, CategoryApplication>();
builder.Services.AddScoped<ICategoryDomain, CategoryDomain>();

// Product Type
builder.Services.AddScoped<IProductTypeApplication, ProductTypeApplication>();
builder.Services.AddScoped<IProductTypeDomain, ProductTypeDomain>();

// Product
builder.Services.AddScoped<IProductApplication, ProductApplication>();
builder.Services.AddScoped<IProductDomain, ProductDomain>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
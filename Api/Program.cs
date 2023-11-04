using Application.Services.Product;
using Application.Services.Product.Contracts;
using Application.Services.Third;
using Application.Services.Third.Contracts;
using Domain.Services.Product;
using Domain.Services.Product.Contracts;
using Domain.Services.Third;
using Domain.Services.Third.Contracts;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Products
builder.Services.AddScoped<IProductDomain, ProductDomain>();
builder.Services.AddScoped<IProductApplication, ProductApplication>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Thirds
builder.Services.AddScoped<IThirdDomain, ThirdDomain>();
builder.Services.AddScoped<IThirdApplication, ThirdApplication>();
builder.Services.AddScoped<IThirdRepository, ThirdRepository>();

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
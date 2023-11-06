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

builder.Services.AddDbContext<InventoryContext>(
    options => options.UseNpgsql(
        "Host=localhost;Database=Inventory;Username=postgres;Password=123456"
    )
);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserApplication, UserApplication>();
builder.Services.AddScoped<IUserDomain, UserDomain>();

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
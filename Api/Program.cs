using Microsoft.EntityFrameworkCore;
using Domain.Services.Contracts;
using Infrastructure.Repositories;
using Libraries.Abstractions;
using Libraries.Routing;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioningRouting();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<InventoryDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("StoreDatabase"))
);

builder.Services.AddApplicationsAsScoped();
builder.Services.AddDomainsAsScoped();

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
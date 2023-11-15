namespace Domain.Services.Contracts;

public interface IProductDomain
{
    Task GetProductAsync();

    Task CreateProductAsync();

    Task FindProductAsync();

    Task InactivateProductAsync();
}
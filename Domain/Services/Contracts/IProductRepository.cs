namespace Domain.Services.Contracts;

public interface IProductRepository
{
    Task<List<Entities.Product>> GetProductAsync();

    Task<Entities.Product> CreateProductAsync();

    Task<Entities.Product> FindProductAsync();
}
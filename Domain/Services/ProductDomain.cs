using Domain.Services.Contracts;

namespace Domain.Services;

public class ProductDomain : IProductDomain
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductDomain(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task GetProductAsync()
    {
        throw new NotImplementedException();
    }

    public Task CreateProductAsync()
    {
        throw new NotImplementedException();
    }

    public Task FindProductAsync()
    {
        throw new NotImplementedException();
    }

    public Task InactivateProductAsync()
    {
        throw new NotImplementedException();
    }
}
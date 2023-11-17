using Domain.Commands;
using Domain.Entities;
using Domain.Services.Contracts;
using Libraries.Abstractions.Contracts;

namespace Domain.Services;

public class SupplierDomain : ISupplierDomain, IDomain
{
    private readonly IUnitOfWork _unitOfWork;

    public SupplierDomain(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> CreateSupplierAsync(CreateSupplierCommand command)
    {
        var supplier = new Supplier
        {
            Name = command.Name,
            Address = command.Address,
            Phone = command.Phone
        };

        return await _unitOfWork.SupplierRepository.CreateUserAsync(supplier);
    }
}
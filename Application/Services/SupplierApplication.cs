using Application.Services.Contracts;
using Domain.Commands;
using Domain.Entities;
using Domain.Services.Contracts;
using Libraries.Abstractions.Contracts;

namespace Application.Services;

public class SupplierApplication : ISupplierApplication, IApplication
{
    private readonly ISupplierDomain _supplierDomain;

    public SupplierApplication(ISupplierDomain supplierDomain)
    {
        _supplierDomain = supplierDomain;
    }

    public async Task<int> CreateSupplierAsync(CreateSupplierCommand command)
    {
        return await _supplierDomain.CreateSupplierAsync(command);
    }
}
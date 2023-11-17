using Domain.Commands;
using Domain.Entities;

namespace Domain.Services.Contracts;

public interface ISupplierDomain
{
    public Task<int> CreateSupplierAsync(CreateSupplierCommand command);
}
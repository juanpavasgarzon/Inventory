using Domain.Commands;
using Domain.Entities;

namespace Application.Services.Contracts;

public interface ISupplierApplication
{
    Task<int> CreateSupplierAsync(CreateSupplierCommand command);
}
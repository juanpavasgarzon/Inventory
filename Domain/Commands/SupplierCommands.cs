namespace Domain.Commands;

public record CreateSupplierCommand(
    string Name,
    string Address,
    string Phone
);
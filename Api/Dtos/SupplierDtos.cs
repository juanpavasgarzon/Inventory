namespace Api.Dtos;

public record CreateSupplierDto(
    string Name,
    string Address,
    string Phone
);
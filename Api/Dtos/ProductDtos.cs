namespace Api.Dtos;

public record ProductTypeDto(string Name);

public record CategoryDto(string Name);

public record BrandDto(string Name);

public record CreateProductDto(
    string Code,
    string Name,
    string Description,
    float UnitPrice,
    float QuantityAvailable,
    ProductTypeDto ProductType,
    CategoryDto Category,
    BrandDto Brand,
    int SupplierId,
    Dictionary<string, string> Observations
);
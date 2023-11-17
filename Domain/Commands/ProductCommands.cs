namespace Domain.Commands;

public record ProductTypeCommand(
    string Name
);

public record CategoryCommand(
    string Name
);

public record BrandCommand(
    string Name
);

public record CreateProductCommand(
    string Code,
    string Name,
    string Description,
    float UnitPrice,
    float QuantityAvailable,
    ProductTypeCommand ProductType,
    CategoryCommand Category,
    BrandCommand Brand,
    int SupplierId,
    Dictionary<string, string> Observations
);
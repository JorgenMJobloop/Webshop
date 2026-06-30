public sealed record CreateProductRequest(
    string name,
    double price,
    int stockQuantity
);
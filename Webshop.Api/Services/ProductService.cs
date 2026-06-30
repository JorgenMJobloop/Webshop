public sealed class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product> CreateProductAsync(string name, double price, int stockQuantity)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Product name is required", nameof(name));
        }

        if (price < 0)
        {
            throw new ArgumentException("Price cannot be less than 0", nameof(price));
        }

        if (stockQuantity < 0)
        {
            throw new ArgumentException("Product is currently not in stock", nameof(stockQuantity));
        }

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = name,
            Price = price,
            StockQuantity = stockQuantity
        };

        await _repository.AddAsync(product);

        return product;
    }

    public async Task<IReadOnlyCollection<Product>> GetProductsAsync()
    {
        return await _repository.GetAllAsync();
    }
}
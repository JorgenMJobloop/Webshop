public sealed class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products =
    [
        new Product
        {
            Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
            Name = "Keyboard",
            Price = 799,
            StockQuantity = 10
        }
    ];
    public Task AddAsync(Product product)
    {
        _products.Add(product);
        return Task.CompletedTask;
    }

    public Task<IReadOnlyCollection<Product>> GetAllAsync()
    {
        return Task.FromResult<IReadOnlyCollection<Product>>(_products);
    }

    public Task<Product?> GetByIdAsync(Guid id)
    {
        return Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
    }

    public Task UpdateAsync(Product product)
    {
        return Task.CompletedTask;
    }
}
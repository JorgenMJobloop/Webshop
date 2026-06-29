public sealed class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }
    public Task<Product> CreateProductAsync(string name, double price, int stockQuantity)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<Product>> GetProductsAsync()
    {
        return _repository.GetAllAsync();
    }
}
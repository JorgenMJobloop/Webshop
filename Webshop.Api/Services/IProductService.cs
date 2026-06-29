public interface IProductService
{
    Task<IReadOnlyCollection<Product>> GetProductsAsync();
    Task<Product> CreateProductAsync(string name, double price, int stockQuantity);
}
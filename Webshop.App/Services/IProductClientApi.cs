using Webshop.Api.Models;
public interface IProductClientApi
{
    Task<IReadOnlyCollection<Product>> GetProductsAsync();
}
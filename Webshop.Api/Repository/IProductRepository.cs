namespace Webshop.Api.Repository;

using Webshop.Api.Models;
public interface IProductRepository
{
    Task<IReadOnlyCollection<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
}
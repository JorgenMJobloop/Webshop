namespace Webshop.Api.Services;

using Webshop.Api.Repository;

public class OrderService : IOrderService
{
    private readonly IProductRepository _productRepository;

    public OrderService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<Order> CreateOrderAsync(Guid productId, int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("Quantity must be greater than 0", nameof(quantity));
        }

        var product = await _productRepository.GetByIdAsync(productId);

        if (product is null)
        {
            throw new InvalidOperationException("Product does not exist in our system!");
        }

        if (product.StockQuantity < quantity)
        {
            throw new ArgumentException($"This product: {product.Name} does not meet the quantity of the order: {quantity}. In stock: {product.StockQuantity}");
        }

        product.StockQuantity -= quantity;

        await _productRepository.UpdateAsync(product);

        return new Order
        {
            Id = Guid.NewGuid(),
            ProductId = productId,
            Quantity = quantity,
            TotalPrice = product.Price * quantity,
            CreatedAtUtc = DateTime.UtcNow
        };
    }
}
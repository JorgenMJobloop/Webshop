public interface IOrderService
{
    Task<Order> CreateOrderAsync(Guid productId, int quantity);
}

using Moq;
using Webshop.Api;
public sealed class OrderServiceTests
{
    [Fact]
    public async Task Order_ShouldBeFilled_WhenQuantity_Is_OK()
    {
        var productId = Guid.NewGuid();

        var product = new Product
        {
            Id = productId,
            Name = "Keyboard",
            Price = 799,
            StockQuantity = 10
        };

        var repositoryMock = new Mock<IProductRepository>();

        repositoryMock.Setup(repo => repo.GetByIdAsync(productId)).ReturnsAsync(product);

        var service = new OrderService(repositoryMock.Object);
        var order = await service.CreateOrderAsync(productId, 2); // should succeed, as we know the quantity in the stock is 10.

        Assert.Equal(productId, order.ProductId);
        Assert.Equal(2, order.Quantity);
        Assert.Equal(1598, order.TotalPrice);
        Assert.Equal(8, product.StockQuantity);

        repositoryMock.Verify(repo => repo.UpdateAsync(product), Times.Once);
    }
}
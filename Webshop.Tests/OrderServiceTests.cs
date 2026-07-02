using Moq;
using Webshop.Api;
using Webshop.Api.Models;
using Webshop.Api.Repository;
using Webshop.Api.Services;
public sealed class OrderServiceTests
{
    [Fact]
    public async Task Order_ShouldBeFilled_WhenQuantity_Is_OK()
    {
        var productId = Guid.NewGuid();

        var product = new Product
        {
            Id = productId,
            Name = "Guitar",
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

    [Fact]
    public async Task CreateOrderAsync_WhenProductDoesNotExist_ThrowsException()
    {
        var repositoryMock = new Mock<IProductRepository>();

        repositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Product?)null);

        var service = new OrderService(repositoryMock.Object);

        await Assert.ThrowsAsync<InvalidOperationException>(() => service.CreateOrderAsync(Guid.NewGuid(), 1));
    }

    [Fact]
    public async Task CreateOrderAsync_WhenStockIsTooLow_ThrowsException()
    {
        var productId = Guid.NewGuid();

        var product = new Product
        {
            Id = productId,
            Name = "Mouse",
            Price = 399,
            StockQuantity = 1
        };

        var repositoryMock = new Mock<IProductRepository>();

        repositoryMock.Setup(repo => repo.GetByIdAsync(productId)).ReturnsAsync(product);

        var service = new OrderService(repositoryMock.Object);

        await Assert.ThrowsAsync<ArgumentException>(() => service.CreateOrderAsync(productId, 5));
    }
}
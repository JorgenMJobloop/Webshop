using Moq;
using Webshop.Api;
using Webshop.Api.Repository;
using Webshop.Api.Services;
public sealed class ProductServiceTests
{
    [Fact]
    public async Task CreateProductAsync_WithValidProduct_ReturnsProduct()
    {
        var repositoryMock = new Mock<IProductRepository>();
        var service = new ProductService(repositoryMock.Object);

        var product = await service.CreateProductAsync("Keyboard", 799, 10);
        Assert.Equal(799, product.Price);
        Assert.Equal("Keyboard", product.Name);
        Assert.Equal(10, product.StockQuantity);

        repositoryMock.Verify(repo => repo.AddAsync(product), Times.Once);
    }

    [Fact]
    public async Task CreateProductAsync_WithInvalidPrice_ThrowsException()
    {
        var repositoryMock = new Mock<IProductRepository>();
        var service = new ProductService(repositoryMock.Object);

        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => service.CreateProductAsync("Mouse", 0, 5));
    }
}
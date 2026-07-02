using Webshop.Api.Models;
using System.Net.Http.Json;
public sealed class ProductApiClient : IProductClientApi
{
    private readonly HttpClient _httpClient;

    public ProductApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<IReadOnlyCollection<Product>> GetProductsAsync()
    {
        var products = await _httpClient.GetFromJsonAsync<IReadOnlyCollection<Product>>("api/products");
        return products ?? [];
    }
}
namespace Webshop.Api.Models;

public class Product
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public double Price { get; init; }
    public int StockQuantity { get; set; } // should preferably be "init", however, this scoping creates undesired behaviour in the reposity layer, the service layer and the controller.
}
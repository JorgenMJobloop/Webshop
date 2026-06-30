public class Product
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public double Price { get; init; }
    public int StockQuantity { get; set; }
}
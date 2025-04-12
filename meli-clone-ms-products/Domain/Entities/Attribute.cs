namespace meli_clone_ms_products.Domain.Entities;

public class Attribute
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
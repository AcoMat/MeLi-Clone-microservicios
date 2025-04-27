namespace meli_clone_ms_products.Infrastructure.External.Dtos;

public class MeLiApiProductDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public long SellerId { get; set; }
    public string CategoryId { get; set; }
    public decimal Price { get; set; }
    public ShippingDto Shipping { get; set; }
    public List<string> PictureUrls { get; set; }
    public string Description { get; set; }
    public List<AttributeDto> Attributes { get; set; }
}

public class ShippingDto
{
    public string Mode { get; set; }
    public List<string> Tags { get; set; }
    public bool FreeShipping { get; set; }
    public string LogisticType { get; set; }
    public bool StorePickUp { get; set; }
}

public class AttributeDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string ValueId { get; set; }
    public string ValueName { get; set; }
    public List<AttributeValueDto> Values { get; set; }
}

public class AttributeValueDto
{
    public string Id { get; set; }
    public string Name { get; set; }
}

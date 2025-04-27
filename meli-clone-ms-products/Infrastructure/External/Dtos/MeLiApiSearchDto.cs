namespace meli_clone_ms_products.Infrastructure.External.Dtos;

public class MeLiApiSearchDto
{
    public string Keywords { get; set; }
    public PagingData Paging { get; set; }
    public List<ProductResult> Results { get; set; }
    
    public class PagingData
    {
        public int Total { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
    }
    
    public class ProductResult
    {
        public string Id { get; set; }
    }
}

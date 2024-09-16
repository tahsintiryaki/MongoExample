namespace MongoDbExample.DTO;

public class CreateProductDetailDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
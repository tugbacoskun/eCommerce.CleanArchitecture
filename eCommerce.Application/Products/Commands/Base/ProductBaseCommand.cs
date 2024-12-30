namespace eCommerce.Application.Products.Commands.Base;

public class ProductBaseCommand
{
    public required  string Name { get; set; }
    public required  string Description { get; set; }
    public decimal Price { get; set; }
}
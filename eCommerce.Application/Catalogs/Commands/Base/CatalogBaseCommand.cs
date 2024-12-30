namespace eCommerce.Application.Catalogs.Commands.Base;

public class CatalogBaseCommand
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public List<Guid> Products { get; set; } = new();
}
namespace eCommerce.Application.Catalogs.Dtos;

public class CatalogDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}
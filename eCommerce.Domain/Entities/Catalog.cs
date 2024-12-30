using eCommerce.Domain.Entities.Base;

namespace eCommerce.Domain.Entities;

public class Catalog : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
} 
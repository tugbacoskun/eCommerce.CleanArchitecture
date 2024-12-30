using eCommerce.Domain.Entities.Base;

namespace eCommerce.Domain.Entities;

public class CatalogProduct : BaseEntity
{
    public Guid CatalogId { get; set; }

    public Guid ProductId { get; set; }
}
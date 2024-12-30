using eCommerce.Application.Catalogs.Commands.Base;
using eCommerce.Application.Common.Interfaces;
using eCommerce.Domain.Entities;
using MediatR;

namespace eCommerce.Application.Catalogs.Commands.CreateCatalog;

public class CreateCatalogCommand : CatalogBaseCommand, IRequest<Guid>
{
}
public class CreateCatalogCommandHandler : IRequestHandler<CreateCatalogCommand, Guid>
{
    private readonly IMongoRepository<Catalog> _catalogRepository;
    private readonly IMongoRepository<CatalogProduct> _catalogProductRepository;
    

    public CreateCatalogCommandHandler(IMongoRepository<Catalog> catalogRepository, IMongoRepository<CatalogProduct> catalogProductRepository)
    {
        _catalogRepository = catalogRepository;
        _catalogProductRepository = catalogProductRepository;
    }

    public async Task<Guid> Handle(CreateCatalogCommand request, CancellationToken cancellationToken)
    {
         
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new ArgumentException("Catalog name is required.");
        }

        if (string.IsNullOrWhiteSpace(request.Description))
        {
            throw new ArgumentException("Catalog description is required.");
        }
 
        var catalog = new Catalog
        { 
            Name = request.Name,
            Description = request.Description 
        };

        await _catalogRepository.AddAsync(catalog);

        foreach (var productId in request.Products)
        {
            await _catalogProductRepository.AddAsync(new CatalogProduct()
            {
                CatalogId = catalog.Id,
                ProductId = productId
            });
        }
        return catalog.Id; 
    }
}

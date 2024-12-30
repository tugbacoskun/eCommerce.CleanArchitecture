using eCommerce.Application.Catalogs.Commands.Base;
using eCommerce.Application.Common.Interfaces;
using eCommerce.Domain.Entities;
using MediatR;

namespace eCommerce.Application.Catalogs.Commands.UpdateCatalog;

public class UpdateCatalogCommand : CatalogBaseCommand, IRequest<Guid>
{
    public Guid Id { get; set; }
}

public class UpdateProductCommandHandler : IRequestHandler<UpdateCatalogCommand, Guid>
{
    private readonly IMongoRepository<Catalog> _catalogRepository;

    public UpdateProductCommandHandler(IMongoRepository<Catalog> catalogRepository)
    {
        _catalogRepository = catalogRepository;
    }

    public async Task<Guid> Handle(UpdateCatalogCommand request, CancellationToken cancellationToken)
    {
        var catalog = await _catalogRepository.GetByIdAsync(request.Id);

        if (catalog == null)
        {
            throw new ArgumentException("Product not found.");
        }

        catalog.Name = request.Name;
        catalog.Description = request.Description;
        await _catalogRepository.UpdateAsync(catalog);


        return request.Id;
    }
}
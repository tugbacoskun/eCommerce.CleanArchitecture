using eCommerce.Application.Common.Interfaces;
using eCommerce.Domain.Entities;
using MediatR;

namespace eCommerce.Application.Catalogs.Commands.DeleteCatalog;

public class DeleteCatalogCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
}

public class DeleteCatalogCommandHandler : IRequestHandler<DeleteCatalogCommand, Guid>
{
    private readonly IMongoRepository<Catalog> _catalogRepository;

    public DeleteCatalogCommandHandler(IMongoRepository<Catalog> catalogRepository)
    {
        _catalogRepository = catalogRepository;
    }

    public async Task<Guid> Handle(DeleteCatalogCommand request, CancellationToken cancellationToken)
    {
        var catalog = await _catalogRepository.GetByIdAsync(request.Id);

        if (catalog == null)
        {
            throw new ArgumentException("Catalog not found.");
        }

        await _catalogRepository.DeleteAsync(request.Id);

        return request.Id;
    }
}
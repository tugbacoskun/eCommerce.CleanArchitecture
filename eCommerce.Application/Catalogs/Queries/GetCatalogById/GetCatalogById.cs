using AutoMapper;
using eCommerce.Application.Catalogs.Dtos;
using eCommerce.Application.Common.Interfaces;
using eCommerce.Domain.Entities;
using MediatR;

namespace eCommerce.Application.Catalogs.Queries.GetCatalogById;

public class GetCatalogByIdQuery : IRequest<CatalogDto>
{
    public Guid Id { get; set; }
}

public class GetCatalogByIdQueryHandler : IRequestHandler<GetCatalogByIdQuery, CatalogDto>
{
    private readonly IMongoRepository<Catalog> _catalogRepository;
    private readonly IMapper _mapper;

    public GetCatalogByIdQueryHandler(IMongoRepository<Catalog> catalogRepository, IMapper mapper)
    {
        _catalogRepository = catalogRepository;
        _mapper = mapper;
    }

    public async Task<CatalogDto> Handle(GetCatalogByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _catalogRepository.GetByIdAsync(request.Id);

        if (product == null)
        {
            throw new ArgumentException("Product not found.");
        }

        return _mapper.Map<CatalogDto>(product);
    } 
}
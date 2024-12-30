using AutoMapper;
using eCommerce.Application.Catalogs.Dtos;
using eCommerce.Application.Common.Interfaces;
using eCommerce.Domain.Entities;
using MediatR;

namespace eCommerce.Application.Catalogs.Queries.GetCatalogs;

public class GetCatalogsQuery :IRequest<List<CatalogDto>>
{
    
}
public class GetCatalogsQueryHandler : IRequestHandler<GetCatalogsQuery, List<CatalogDto>>
{
    private readonly IMongoRepository<Catalog> _catalogRepository;
    private readonly IMapper _mapper;

    public GetCatalogsQueryHandler(IMongoRepository<Catalog> catalogRepository, IMapper mapper)
    {
        _catalogRepository = catalogRepository;
        _mapper = mapper;
    }

    public async Task<List<CatalogDto>> Handle(GetCatalogsQuery request, CancellationToken cancellationToken)
    {
        var products = await _catalogRepository.GetAllAsync();
        
        return _mapper.Map<List<CatalogDto>>(products);
    }
}
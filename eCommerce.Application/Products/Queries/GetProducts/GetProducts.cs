using AutoMapper;
using eCommerce.Application.Common.Interfaces;
using eCommerce.Application.Products.Dtos;
using eCommerce.Domain.Entities;
using MediatR;

namespace eCommerce.Application.Products.Queries.GetProducts;

public class GetProductsQuery :IRequest<List<ProductDto>>
{
    
}
public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
{
    private readonly IMongoRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public GetProductsQueryHandler(IMongoRepository<Product> productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync();
        
        return _mapper.Map<List<ProductDto>>(products);
    }
}
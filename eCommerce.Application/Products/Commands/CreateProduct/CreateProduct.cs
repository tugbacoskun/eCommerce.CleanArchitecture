using eCommerce.Application.Common.Interfaces;
using eCommerce.Application.Products.Commands.Base;
using eCommerce.Domain.Entities;
using MediatR;

namespace eCommerce.Application.Products.Commands.CreateProduct;

public class CreateProductCommand :ProductBaseCommand, IRequest<Guid>
{
    
}
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IMongoRepository<Product> _productRepository;

    public CreateProductCommandHandler(IMongoRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new ArgumentException("Product name is required.");
        }

        if (request.Price <= 0)
        {
            throw new ArgumentException("Price must be greater than zero.");
        }

        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price
        };

        await _productRepository.AddAsync(product);

        return product.Id;
    }
}
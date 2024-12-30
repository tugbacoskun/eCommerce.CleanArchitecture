using eCommerce.Application.Common.Interfaces;
using eCommerce.Application.Products.Commands.Base;
using eCommerce.Domain.Entities;
using MediatR;

namespace eCommerce.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommand : ProductBaseCommand, IRequest<Guid>
{
    public Guid Id { get; set; }
}

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Guid>
{
    private readonly IMongoRepository<Product> _productRepository;

    public UpdateProductCommandHandler(IMongoRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Guid> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product == null)
        {
            throw new ArgumentException("Product not found.");
        }

        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;

        await _productRepository.UpdateAsync(product);

        return request.Id;
    }
}
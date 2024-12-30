using eCommerce.Application.Common.Interfaces;
using eCommerce.Domain.Entities;
using MediatR;

namespace eCommerce.Application.Products.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
}

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Guid>
{
    private readonly IMongoRepository<Product> _productRepository;

    public DeleteProductCommandHandler(IMongoRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Guid> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product == null)
        {
            throw new ArgumentException("Product not found.");
        }

        await _productRepository.DeleteAsync(request.Id);

        return request.Id;
    }
}
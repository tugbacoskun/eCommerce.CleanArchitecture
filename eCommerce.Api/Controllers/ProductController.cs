using eCommerce.Application.Products.Commands.CreateProduct;
using eCommerce.Application.Products.Commands.DeleteProduct;
using eCommerce.Application.Products.Commands.UpdateProduct;
using eCommerce.Application.Products.Dtos;
using eCommerce.Application.Products.Queries.GetProductById;
using eCommerce.Application.Products.Queries.GetProducts;
using eCommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        var productId = await _mediator.Send(command);
        return Ok(new { Id = productId });
    }

    [HttpPut]
    public async Task<Guid> UpdateProduct([FromBody] UpdateProductCommand command)
    {
        return await _mediator.Send(command); 
    }

    [HttpGet("{id}")]
    public async Task<ProductDto> GetProductById(Guid id)
    {
        return await _mediator.Send(new GetProductByIdQuery { Id = id }); 
    }

    [HttpGet]
    public async Task<List<ProductDto>> GetProducts()
    {
        return await _mediator.Send(new GetProductsQuery());
    }

    [HttpDelete("{id}")]
    public async Task<Guid> DeleteProduct(Guid id)
    {
        return  await _mediator.Send(new DeleteProductCommand { Id = id }); 
    }
}
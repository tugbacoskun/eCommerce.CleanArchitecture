using eCommerce.Application.Catalogs.Commands.CreateCatalog;
using eCommerce.Application.Catalogs.Commands.DeleteCatalog;
using eCommerce.Application.Catalogs.Commands.UpdateCatalog;
using eCommerce.Application.Catalogs.Dtos;
using eCommerce.Application.Catalogs.Queries.GetCatalogById;
using eCommerce.Application.Catalogs.Queries.GetCatalogs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CatalogsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CatalogsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<Guid> CreateCatalog([FromBody] CreateCatalogCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut]
    public async Task<Guid> UpdateCatalog([FromBody] UpdateCatalogCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<Guid> DeleteCatalog(Guid id)
    {
        return await _mediator.Send(new DeleteCatalogCommand { Id = id });
    }

    [HttpGet("{id}")]
    public async Task<CatalogDto> GetCatalogById(Guid id)
    {
        return await _mediator.Send(new GetCatalogByIdQuery { Id = id });
    }

    [HttpGet]
    public async Task<List<CatalogDto>> GetCatalogs()
    {
        return await _mediator.Send(new GetCatalogsQuery());
    }
}
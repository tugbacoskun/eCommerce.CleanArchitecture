using AutoMapper;
using eCommerce.Application.Catalogs.Dtos;
using eCommerce.Application.Products.Dtos;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Common.Mapping;

public class Mapping: Profile
{
    public Mapping()
    {
        CreateMap<Catalog, CatalogDto>();
        CreateMap<Product, ProductDto>();
    }   
}
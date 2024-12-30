using AutoMapper;
using eCommerce.Application.Products.Commands.Base;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Products.Dtos;

public class ProductDto : ProductBaseCommand
{
    public Guid Id { get; set; }
}
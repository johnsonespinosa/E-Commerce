using Application.DTOs;
using Application.Models;
using Ardalis.Specification;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries.GetAll;

internal sealed class GetAllProductsQueryHandler(IMapper mapper, IReadRepositoryBase<Product> repository)
    : IRequestHandler<GetAllProductsQuery, PaginatedList<ProductDto>>
{
    public async Task<PaginatedList<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await repository.ListAsync(cancellationToken);
        var result = mapper.Map<List<ProductDto>>(products);
        return await PaginatedList<ProductDto>.CreateAsync(source: result.AsQueryable(), request.PageNumber, request.PageSize);
    }
}
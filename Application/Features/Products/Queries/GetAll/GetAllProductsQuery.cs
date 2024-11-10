using Application.DTOs;
using Application.Models;
using MediatR;

namespace Application.Features.Products.Queries.GetAll;

public record GetAllProductsQuery(int PageSize, int PageNumber) : IRequest<PaginatedList<ProductDto>>;
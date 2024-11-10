using Application.DTOs;
using MediatR;

namespace Application.Features.Products.Queries.GetById;

public record GetProductByIdQuery(Guid Id) : IRequest<ProductDto>;
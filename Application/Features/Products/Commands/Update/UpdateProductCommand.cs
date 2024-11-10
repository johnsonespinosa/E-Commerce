using Application.Models;
using MediatR;

namespace Application.Features.Products.Commands.Update;

public record UpdateProductCommand(
    Guid Id,
    Guid CategoryId,
    string Name,
    string Description,
    string Image,
    decimal SellPrice,
    decimal PurchasePrice,
    int Stock
    ) : IRequest<Result>;
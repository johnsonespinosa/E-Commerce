using Application.Models;
using MediatR;

namespace Application.Features.Products.Commands.Create;

public record CreateProductCommand(
    Guid CategoryId,
    string Name,
    string Description,
    string Image,
    decimal SellPrice, 
    decimal PurchasePrice,
    int Stock
    ) : IRequest<Result>;
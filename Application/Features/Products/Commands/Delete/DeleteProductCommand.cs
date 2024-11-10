using Application.Models;
using MediatR;

namespace Application.Features.Products.Commands.Delete;

public record DeleteProductCommand(Guid Id) : IRequest<Result>;
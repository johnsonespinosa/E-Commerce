using Application.Models;
using Ardalis.Specification;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.Create;

internal sealed class CreateProductCommandHandler(IMapper mapper, IRepositoryBase<Product> repository)
    : IRequestHandler<CreateProductCommand, Result>
{
    public async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await repository.AddAsync(entity: mapper.Map<Product>(request), cancellationToken);
        return Result.Success(product.Id);
    }
}
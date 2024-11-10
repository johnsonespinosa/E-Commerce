using Application.Models;
using Ardalis.Specification;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.Delete;

internal sealed class DeleteProductCommandHandler(IRepositoryBase<Product> repository)
    : IRequestHandler<DeleteProductCommand, Result>
{
    public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await repository.GetByIdAsync(request.Id, cancellationToken);
        product!.Available = false;
        await repository.UpdateAsync(product, cancellationToken);
        return Result.Success(product.Id);
    }
}
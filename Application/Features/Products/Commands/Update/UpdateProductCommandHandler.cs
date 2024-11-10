using Application.Models;
using Ardalis.Specification;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.Update;

internal sealed class UpdateProductCommandHandler(IMapper mapper, IRepositoryBase<Product> repository)
    : IRequestHandler<UpdateProductCommand, Result>
{
    public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await repository.GetByIdAsync(request.Id, cancellationToken);
        mapper.Map(product, request);
        await repository.UpdateAsync(product!, cancellationToken);
        return Result.Success(product!.Id);
    }
}
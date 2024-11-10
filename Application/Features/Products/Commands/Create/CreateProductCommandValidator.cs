using FluentValidation;

namespace Application.Features.Products.Commands.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(expression: command => command.CategoryId)
            .NotEmpty().WithMessage("Debe especificar una categoría para el producto.");

        RuleFor(expression: command => command.Name)
            .NotEmpty().WithMessage("El nombre del producto es obligatorio.")
            .Length(1, 100).WithMessage("El nombre del producto debe tener entre 1 y 100 caracteres.");

        RuleFor(expression: command => command.Description)
            .MaximumLength(500).WithMessage("La descripción no puede exceder los 500 caracteres.");

        RuleFor(expression: command => command.SellPrice)
            .GreaterThan(valueToCompare: 0).WithMessage("El precio de venta debe ser mayor que cero.");

        RuleFor(expression: command => command.PurchasePrice)
            .GreaterThan(valueToCompare: 0).WithMessage("El precio de compra debe ser mayor que cero.")
            .LessThanOrEqualTo(expression: command => command.SellPrice)
            .WithMessage("El precio de compra no puede ser mayor que el precio de venta.");

        RuleFor(expression: command => command.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("El stock no puede ser negativo.");
    }
}
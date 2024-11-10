using FluentValidation.Results;

namespace Application.Exceptions;

public class ValidationException() : Exception(message: "Se han producido uno o más errores de validación.")
{
    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures
            .GroupBy(validationFailure => validationFailure.PropertyName, validationFailure => validationFailure.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }

    public IDictionary<string, string[]> Errors { get; } = new Dictionary<string, string[]>();
}
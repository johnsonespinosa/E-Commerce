namespace Application.Models;

public class Result
{
    private Result(IEnumerable<string> errors)
    {
        Succeeded = false;
        Errors = errors.ToArray();
    }
    private Result(Guid value, string[] errors)
    {
        Succeeded = true;
        Value = value;
        Errors = errors;
    }

    public bool Succeeded { get; init; }

    public Guid Value { get; set; }
    public string[] Errors { get; init; }

    public static Result Success(Guid id)
    {
        return new Result(id, errors: []);
    }

    public static Result Failure(IEnumerable<string> errors)
    {
        return new Result(errors);
    }
}
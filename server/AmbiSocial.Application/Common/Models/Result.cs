namespace AmbiSocial.Application.Common.Models;

public class Result
{
    private readonly List<string> errors;

    internal Result(bool succeeded, List<string> errors)
    {
        this.Succeeded = succeeded;
        this.errors = errors;
    }

    public bool Succeeded { get; }

    public List<string> Errors
        => this.Succeeded
            ? new List<string>()
            : this.errors;

    public static Result Success
        => new(true, new List<string>());

    public static Result Failure(IEnumerable<string> errors)
        => new(false, errors.ToList());
}

public class Result<TData> : Result
{
    private readonly TData data;

    private Result(bool succeeded, TData data, List<string> errors)
        : base(succeeded, errors)
        => this.data = data;

    public TData Data
        => this.Succeeded
            ? this.data
            : throw new InvalidOperationException($"{nameof(this.Data)} is not available with a failed result. Use {this.Errors} instead");

    public static Result<TData> SuccessWith(TData data)
        => new(true, data, new List<string>());

    public new static Result<TData> Failure(IEnumerable<string> errors)
        => new(false, default!, errors.ToList());
}
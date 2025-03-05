using FluentValidation.Results;

namespace HelpPoint.Common.Errors;

public class HelpPointValidationException : Exception
{
    public int StatusCode { get; } = 400;
    public Dictionary<string, string[]> Errors { get; }

    public HelpPointValidationException(ValidationResult validationResult)
        : base("Validation failed")
    {
        Errors = new Dictionary<string, string[]>();

        foreach (var failure in validationResult.Errors)
        {
            if (!Errors.TryGetValue(failure.PropertyName, out var value))
            {
                Errors[failure.PropertyName] = [failure.ErrorMessage];
            }
            else
            {
                var errors = new List<string>(value) { failure.ErrorMessage };
                Errors[failure.PropertyName] = [.. errors];
            }
        }
    }
}


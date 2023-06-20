using ErrorOr;

using FluentValidation;

using MediatR;

namespace Application.Common.Behaviors;

/// <summary>
/// Validation of behaviors.
/// </summary>
/// <typeparam name="TRequest">Request Type Parameter.</typeparam>
/// <typeparam name="TResponse">Response Type Parameter.</typeparam>
public class ValidationBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationBehavior{TRequest, TResponse}"/> class.
    /// </summary>
    /// <param name="validator">Object validator implementation.</param>
    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    /// <summary>
    /// Handles Behavior Validation.
    /// </summary>
    /// <param name="request">Request Type Parameter.</param>
    /// <param name="next">Request Handler Delegate.</param>
    /// <param name="cancellationToken">Cancellation Token.</param>
    /// <returns>TResponse.</returns>
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validator is null)
        {
            return await next();
        }

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            return await next();
        }

        var errors = validationResult.Errors
            .Select(validationFailure => Error.Validation(
                validationFailure.PropertyName,
                validationFailure.ErrorMessage))
            .ToList();

        return (dynamic)errors; // It's dangerous to use dynamic
    }
}

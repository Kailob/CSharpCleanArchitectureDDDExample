﻿using FluentValidation;

namespace Application.Authentication.Queries.Login;

/// <summary>
/// Login Query Validator.
/// </summary>
public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LoginQueryValidator"/> class.
    /// </summary>
    public LoginQueryValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}

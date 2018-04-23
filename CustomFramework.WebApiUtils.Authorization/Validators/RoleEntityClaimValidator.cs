﻿using CustomFramework.WebApiUtils.Authorization.Constants;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace CustomFramework.WebApiUtils.Authorization.Validators
{
    public class RoleEntityClaimValidator : AbstractValidator<RoleEntityClaimRequest>
    {
        public RoleEntityClaimValidator()
        {
            RuleFor(x => x.RoleId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.RoleId}");

            RuleFor(x => x.Entity)
                .NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.Entity}")
                .MaximumLength(50)
                .WithMessage($"{ValidatorConstants.MaxLengthError} : {AuthorizationConstants.Entity}, 50");

        }
    }
}
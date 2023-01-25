﻿using Application.Constants;
using Application.Features.SystemStaffAuth.Queries;
using FluentValidation;

namespace Application.Validators.SystemStaffs.Auth
{
    public class SystemStaffLoginAuthValidator : AbstractValidator<SystemStaffLoginQuery>
    {
        public SystemStaffLoginAuthValidator()
        {
            RuleFor(ss => ss.Email).NotEmpty().EmailAddress().WithMessage(ValidationMessages.EmailFormat);
            RuleFor(ss => ss.Password).NotEmpty().WithMessage(ValidationMessages.PasswordCantEmpty);
        }
    }
}
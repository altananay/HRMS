﻿using Application.Constants;
using Domain.Objects;
using FluentValidation;

namespace Application.Validators.Cvs
{
    public class HobbyValidator : AbstractValidator<Hobby>
    {
        public HobbyValidator()
        {
            RuleFor(h => h.Hobbies).NotEmpty().WithMessage(ValidationMessages.HobbiesCantEmpty);
        }
    }
}
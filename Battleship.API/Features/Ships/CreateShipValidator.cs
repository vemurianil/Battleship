using System;
using Battleship.API.Data;
using FluentValidation;

namespace Battleship.API.Features.Ships
{
    public class CreateShipValidator : AbstractValidator<CreateShip>
    {
        public CreateShipValidator()
        {
            RuleFor(c => c.BoardId)
                .GreaterThan(0)
                .NotEmpty();

            RuleFor(c => c.X)
                .GreaterThan(0)
                .WithMessage("X coordinate should be greater than 0")
                .NotEmpty();

            RuleFor(c => c.Y)
                .GreaterThan(0)
                .WithMessage("Y coordinate should be greater than 0")
                .NotEmpty();

            RuleFor(c => c.Size)
                .GreaterThanOrEqualTo(2)
                .WithMessage("Minimum length of Ship is 2")
                .LessThanOrEqualTo(5)
                .WithMessage("Maximum length of Ship is 5")
                .NotEmpty();
        }
    }
}


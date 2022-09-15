using System;
using Battleship.API.Data;
using FluentValidation;

namespace Battleship.API.Features.Attack
{
    public class AttackValidator : AbstractValidator<Attack>
    {
        private readonly IBattleshipDbContext _context;

        public AttackValidator(IBattleshipDbContext context)
        {
            _context = context;

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
        }
    }
}


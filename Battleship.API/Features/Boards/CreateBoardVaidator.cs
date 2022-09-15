using System;
using FluentValidation;

namespace Battleship.API.Features.Boards
{
    public class CreateBoardValidator : AbstractValidator<CreateBoard>
    {
        public CreateBoardValidator()
        {
            RuleFor(x => x.GridSize)
                .GreaterThanOrEqualTo(5)
                .WithMessage("Minimum grid size of the board is 5.")
                .LessThanOrEqualTo(10)
                .WithMessage("Maximum grid size of the board is 10.");
        }
    }
}


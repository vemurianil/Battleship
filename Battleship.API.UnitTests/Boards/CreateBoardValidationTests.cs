using System;
using FluentValidation.TestHelper;
using Battleship.API.Features.Boards;

namespace Battleship.API.UnitTests.Boards
{
    public class CreateBoardValidationTests
    {
        private readonly CreateBoardValidator _validator;

        public CreateBoardValidationTests()
        {
            _validator = new CreateBoardValidator();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(4)]
        [InlineData(11)]
        public void Should_Fail_When_Invalid_GridSize(int gridSize)
        {
            var result = _validator.TestValidate(new CreateBoard
            {
                GridSize = gridSize
            });
            result.ShouldHaveValidationErrorFor(x => x.GridSize);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        public void Should_Not_Fail_When_Valid_GridSize(int gridSize)
        {
            var result = _validator.TestValidate(new CreateBoard
            {
                GridSize = gridSize
            });
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}


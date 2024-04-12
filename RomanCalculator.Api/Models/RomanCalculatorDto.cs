using FluentValidation;
using Math.Roman;
using RomanCalculator.Api.Enums;

namespace RomanCalculator.Api.Models
{
    public class RomanCalculatorDto
    {
        public required string Left { get; set; }
        public required string Right { get; set; }
        public RomanOperator Operator { get; set; }

        public class Validator : AbstractValidator<RomanCalculatorDto>
        {
            public Validator()
            {
                RuleFor(x => x.Left).NotEmpty().Must(x => Roman.TryParse(x, out _) == true).WithMessage("Left operand is not a valid roman numeral");
                RuleFor(x => x.Right).NotEmpty().Must(x => Roman.TryParse(x, out _) == true).WithMessage("Right operand is not a valid roman numeral");
                RuleFor(x => x.Operator).IsInEnum();
            }
        }
    }
}

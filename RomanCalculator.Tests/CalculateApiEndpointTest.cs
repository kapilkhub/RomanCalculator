using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using RomanCalculator.Api.EndpointHandlers;
using RomanCalculator.Api.Models;
using RomanCalculator.Api.Enums;
using Math.Roman;

namespace RomanCalculator.Tests
{
    public class CalculateApiEndpointTest
    {
        private Mock<IValidator<RomanCalculatorDto>> _mockValidator;

		public CalculateApiEndpointTest()
        {
			 _mockValidator = new Mock<IValidator<RomanCalculatorDto>>();
			_mockValidator.Setup(m => m.Validate(It.IsAny<RomanCalculatorDto>())).Returns(
				new FluentValidation.Results.ValidationResult());

		}
		[Theory]
        [InlineData("IV", "+", "I", "V")]
        [InlineData("V", "+", "IX", "XIV")]
        [InlineData("IV", "-", "I", "III")] // 4-1 =3
        [InlineData("MDCCCLXIX", "-", "CDLXVII", "MCDII")] // 1869 - 467  = 1402
        [InlineData("VIII", "/", "II", "IV")] // 8 / 2 = 4
        [InlineData("MMCMLXXXVIII", "/", "XIV", "CCXIII")] // 2988 / 14 = 4
        [InlineData("IV", "*", "V", "XX")] //4 * 5 = 20
        [InlineData("LXXVII", "*", "LI", "MMMCMXXVII")] // 77 * 51 = 3927      
        public void test_calculate_api_end_point(string left, string operation, string right, string expectedRoman)
        {
          
            var romanOperator = operation switch
            {
                "+" => RomanOperator.Add,
                "-" => RomanOperator.Subtract,
                "/" => RomanOperator.Divide,
                "*" => RomanOperator.Multiply,
                _ => throw new ArgumentOutOfRangeException($"invalid {nameof(operation)}")
            };

            var result =
                RomanCalculatorHandler.Calculate(_mockValidator.Object, new RomanCalculatorDto { Left = left, Right = right, Operator = romanOperator });

           var apiResult =  Assert.IsType<Ok<Roman>>(result);

            Roman.TryParse(expectedRoman, out var expectedResult);
            Assert.Equal(expectedResult!.RomanNumeral, apiResult!.Value!.RomanNumeral);


        }

		[Theory]
		[InlineData("V", "-", "V" )] //=0, there is no roman number that represent 0 
		[InlineData("X", "/", "XX")] //=0, there is no roman number that represent 0 

		public void test_calculate_api_end_point_out_of_bound(string left, string operation, string right)
        {
			var romanOperator = operation switch
			{
				"+" => RomanOperator.Add,
				"-" => RomanOperator.Subtract,
				"/" => RomanOperator.Divide,
				"*" => RomanOperator.Multiply,
				_ => throw new ArgumentOutOfRangeException($"invalid {nameof(operation)}")
			};

			var result =
			   RomanCalculatorHandler.Calculate(_mockValidator.Object, new RomanCalculatorDto { Left = left, Right = right, Operator = romanOperator });

            Assert.IsType<ProblemHttpResult>(result);
		}
	}
}
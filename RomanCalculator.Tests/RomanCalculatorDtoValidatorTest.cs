using FluentValidation.TestHelper;
using RomanCalculator.Api.Enums;
using RomanCalculator.Api.Models;

namespace RomanCalculator.Tests
{
    public class RomanCalculatorDtoValidatorTest
    {
        private RomanCalculatorDto.Validator _validator;
        public RomanCalculatorDtoValidatorTest()
        {
            _validator = new RomanCalculatorDto.Validator();
        }

        [Theory]
        [InlineData("","I",RomanOperator.Add)]
        [InlineData("I", "", RomanOperator.Add)]
        [InlineData("IVV", "II", RomanOperator.Add)]
        [InlineData("IV", "IIV", RomanOperator.Add)]

        public void test_roman_calculator_validator_for_invalid_data(string left, string right, RomanOperator romanOperator)
        {
            // Arrange
            var model = new RomanCalculatorDto { Left = left,Right=right, Operator = romanOperator };
           
            //Act
            var result = _validator.TestValidate(model);

            //Assert
            Assert.False(result.IsValid);
            
        }

        [Theory]
        [InlineData("I", "I", RomanOperator.Add)]
        public void roman_calculator_validator_for_valid_data(string left, string right, RomanOperator romanOperator)
        {

            var model = new RomanCalculatorDto { Left = left, Right = right, Operator = romanOperator };

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            Assert.True(result.IsValid);
        }
    }
}

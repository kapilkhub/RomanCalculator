using FluentValidation;
using Math.Roman;
using RomanCalculator.Api.Models;
using RomanCalculator.Api.Enums;
using System.Net;

namespace RomanCalculator.Api.EndpointHandlers
{
    public static class RomanCalculatorHandler
    {
        public static IResult Calculate(
            IValidator<RomanCalculatorDto> validator, [AsParameters] RomanCalculatorDto romanCalculator)
        {
            var validationResult = validator.Validate(romanCalculator);
            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary(),
                    statusCode: (int)HttpStatusCode.UnprocessableEntity);

            }
            Roman A = new Roman(romanCalculator.Left);
			Roman B = new Roman(romanCalculator.Right);

			try
            {
				var result = romanCalculator.Operator switch
				{
					RomanOperator.Add => A + B,
					RomanOperator.Subtract => A - B,
					RomanOperator.Divide => A / B,
					RomanOperator.Multiply => A * B,
					_ => throw new ArgumentOutOfRangeException($"invalid {nameof(romanCalculator.Operator)}")
				};
				return TypedResults.Ok(result);
			}
            catch  (Exception)
            {
				   return Results.ValidationProblem(validationResult.ToDictionary(),
				   statusCode: (int)HttpStatusCode.UnprocessableEntity);

			}


		}
    }
}

using RomanCalculator.Api.EndpointHandlers;
using RomanCalculator.Api.Models;

namespace RomanCalculator.Api.Extensions
{
    public static class EndpointRouteBuilderExtensions
    {
        public static void RegisterRomanCalculatorEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var romanEndPoints = endpointRouteBuilder.MapGroup("/roman");

            romanEndPoints.MapGet("/calculate", RomanCalculatorHandler.Calculate);
        }
    }
}

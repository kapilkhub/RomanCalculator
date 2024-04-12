
using RomanCalculator.UI.Model;

namespace RomanCalculator.UI.Services
{
    public interface IRomanDataService
    {
		Task<HttpResponse<Roman>> Calculate(RomanCalculatorDto dto, CancellationToken ct = default);
	}
}

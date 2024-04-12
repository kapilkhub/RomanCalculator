using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RomanCalculator.UI.Model;
using System;
using System.Text.Json;

namespace RomanCalculator.UI.Services
{
    public class RomanDataService : IRomanDataService
    {
        private readonly HttpClient _httpClient;

        public RomanDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponse<Roman>> Calculate(RomanCalculatorDto dto, CancellationToken ct)
        {
			string resource =$"calculate?Left={dto.Left}&Right={dto.Right}&Operator={dto.Operator}";
			var result = await _httpClient.GetAsync(resource, ct);

			return new HttpResponse<Roman>
			{
				StatusCode = result.StatusCode,
				Response = result.IsSuccessStatusCode ?  JsonConvert.DeserializeObject<Roman>(await result.Content.ReadAsStringAsync()): null
			};

		}

		

	}
}

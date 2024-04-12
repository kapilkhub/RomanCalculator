using Microsoft.AspNetCore.Components;
using RomanCalculator.UI.Model;
using RomanCalculator.UI.Services;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace RomanCalculator.UI.Pages
{
    public partial class Index
	{
		public RomanInputModel RomanInputModel = new();

		public List<RomanOperator> RomanOperators = new List<RomanOperator>
						  { RomanOperator.Add,RomanOperator.Subtract,RomanOperator.Multiply,RomanOperator.Divide };

		[Inject]
		public required IRomanDataService RomanDataService { get; set; }

		protected string Message = string.Empty;
		protected string StatusClass = string.Empty;

		private void HandleInValidSubmit()
		{
			StatusClass = "alert alert-danger";
			Message = "There are some validation errors. Please try again.";
		}

		private async Task HandleValidSubmit()
		{
			var result = await RomanDataService.Calculate(new RomanCalculatorDto
			{
				Left = RomanInputModel.Left,
				Right = RomanInputModel.Right,
				Operator = RomanInputModel.OperatorId
			});

			if (result?.StatusCode == HttpStatusCode.OK)
			{
				StatusClass = "alert alert-success";
				Message = $"Result for Operation {RomanInputModel.OperatorId} is {result?.Response?.RomanNumeral}";
			}
			else
			{
				StatusClass = "alert alert-danger";
				Message = $"Input is not valid";
			}

		}


	}
}

public class RomanInputModel
{
	[Required]
	public string Left { get; set; }
	[Required]
	public string Right { get; set; }

	[Required]
	public RomanOperator OperatorId { get; set; }
}



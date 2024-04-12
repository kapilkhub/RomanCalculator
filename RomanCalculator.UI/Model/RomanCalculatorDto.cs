namespace RomanCalculator.UI.Model
{
	public sealed class RomanCalculatorDto
    {
        public required string Left { get; set; }
        public required string Right { get; set; }
        public RomanOperator Operator { get; set; }
    }

    public enum RomanOperator
    {
        Add,
        Subtract,
        Multiply,
        Divide

    }

    public sealed class Roman 
    {
        public string? RomanNumeral { get; set; }

    }


}

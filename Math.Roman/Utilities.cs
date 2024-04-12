using System.Text;

namespace Math.Roman
{
    /// <summary>
    /// Class for changing types To and From Roman
    /// 
    /// </summary>
    internal static partial class Convert
    {
       static Dictionary<char, int> romanMap = new Dictionary<char, int>()
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000},
                {'Z', 5000 }
            };
        /// <summary>
        /// Convert valid roman number to equivalent integer.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        internal static int ToInt32(Roman value)
        {
            int integer = 0;
            for (int i = 0; i < value.RomanNumeral.Length; i++)
            {
                if (i + 1 < value.RomanNumeral.Length && romanMap[value.RomanNumeral[i]] < romanMap[value.RomanNumeral[i + 1]])
                {
                    integer -= romanMap[value.RomanNumeral[i]];
                }
                else
                {
                    integer += romanMap[value.RomanNumeral[i]];
                }
            }
            return integer;

        }

        /// <summary>
        /// Convert integer to roman value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        internal static string ToRomanString(int value)
        {
            Guards.Against.InvalidInteger(value, nameof(value));

            StringBuilder result = new();
            int remaining = value;
            int threshold = 0;
            string thresholdRoman = string.Empty;

            while (remaining > 0)
            {
                int numberOfDigits = remaining.ToString().Count();
                if (numberOfDigits == 1)
                {
                    threshold = 1;
                    thresholdRoman = "I";
                }
                else if (numberOfDigits == 2)
                {
                    threshold = 10;
                    thresholdRoman = "X";
                }
                else if (numberOfDigits == 3)
                {
                    threshold = 100;
                    thresholdRoman = "C";
                }
                else if (numberOfDigits == 4)
                {
                    threshold = 1000;
                    thresholdRoman = "M";
                }
                remaining = CalculateRoman(result, remaining, threshold, thresholdRoman);

            }
            return result.ToString();
        }


        private static int CalculateRoman(StringBuilder result, int remaining, int threshold, string thresholdRoman)
        {
            var nearestPossibleRoman = romanMap.Select((Value, Key) => new { Value, Key }).Where(a => a.Value.Value > remaining).First();
            var upperBound = romanMap.ElementAt(nearestPossibleRoman.Key);
            var lowerbound = romanMap.ElementAt(nearestPossibleRoman.Key == 0 ? nearestPossibleRoman.Key : nearestPossibleRoman.Key - 1);
            if (upperBound.Value - remaining <= threshold)
            {
                result.Append(thresholdRoman); 
                result.Append(upperBound.Key);
                remaining = remaining - (upperBound.Value - threshold);
            }
            else
            {

                result.Append(lowerbound.Key);
                remaining = remaining - lowerbound.Value;
            }

            return remaining;
        }
    }
}

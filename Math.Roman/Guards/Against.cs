using System.Text.RegularExpressions;

namespace Math.Roman.Guards
{
    internal static class Against
    {

      /// <summary>
      /// Guard against empty string.
      /// </summary>
      /// <param name="romanNumeral"></param>
      /// <param name="parameterName"></param>
      /// <exception cref="ArgumentException"></exception>
       private  static void NullOrEmpty(string romanNumeral, string parameterName)
        {
            if (string.IsNullOrEmpty(romanNumeral))
            {
                throw new ArgumentException($"{parameterName} cannot be empty");
            }
        }

       

        /// <summary>
        /// Guard against invalid roman number.
        /// </summary>
        /// <param name="roman"></param>
        /// <param name="parameterName"></param>
        /// <exception cref="ArgumentException"></exception>
        private static void InvalidRoman(string romanNumeral, string parameterName)
        {
            // Regular expression to match valid Roman numerals
            Regex romanRegex = new Regex("^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$", RegexOptions.IgnoreCase);
            if (!romanRegex.IsMatch(romanNumeral)) 
            {
                throw new ArgumentException($"{parameterName} is not a valid roman numeral");
            }
        }

        
        /// <summary>
        /// Guard against invalid roman numeral
        /// </summary>
        /// <param name="romanNumeral"></param>
        /// <param name="parameterName"></param>
        internal static void InvalidRomanNumeral(string romanNumeral, string parameterName)
        {
            NullOrEmpty(romanNumeral, parameterName);
            romanNumeral = romanNumeral.ToUpper();
            InvalidRoman(romanNumeral, parameterName);
        }

        /// <summary>
        /// Guard against invalid integer number. 
        /// </summary>
        /// <param name="integerValue"></param>
        /// <param name="parameterName"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        internal static void InvalidInteger(int integerValue, string parameterName)
        {
            if (integerValue <=0 || integerValue > 3999)
            {
                throw new ArgumentOutOfRangeException($"{parameterName} range is invalid. Only positive number less than or equal to 3999 can be converted into roman number ");
            }
        }
    }
}

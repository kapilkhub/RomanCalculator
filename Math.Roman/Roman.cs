using System.Runtime.CompilerServices;

namespace Math.Roman
{
    public sealed class Roman
    {

        public string RomanNumeral { get; init; }

        /// <summary>
        /// provide a roman numeral string. String must only contain these roman characters.
        /// 'I'
        /// 'V'
        /// 'X'
        /// 'L'
        /// 'C'
        /// 'D'
        /// 'M'
        /// </summary>
        /// <param name="romanNumeral"></param>
        public Roman(string romanNumeral)
        {
            Guards.Against.InvalidRomanNumeral(romanNumeral, nameof(romanNumeral));
            RomanNumeral = romanNumeral.ToUpper();
        }

        public static bool TryParse(string romanNumeral, out Roman? result)
        {
            result = null;
            try
            {
                result = new Roman(romanNumeral);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// Roman Add
        /// </summary>
        /// <param name="left">Left Operand</param>
        /// <param name="right">Right Operand</param>
        /// <returns>Roman numeral</returns>
        public static Roman operator +(Roman left, Roman right)
        {
            int result = Convert.ToInt32(left) + Convert.ToInt32(right);

            return new Roman(Convert.ToRomanString(result));
        }

        /// <summary>
        /// Roman Subtract
        /// </summary>
        /// <param name="left">Left Operand</param>
        /// <param name="right">Right Operand</param>
        /// <returns>Roman numeral</returns>
        public static Roman operator -(Roman left, Roman right)
        {
            int result = Convert.ToInt32(left) - Convert.ToInt32(right);

            return new Roman(Convert.ToRomanString(result));
        }

        /// <summary>
        /// Roman Division
        /// </summary>
        /// <param name="left">Left Operand</param>
        /// <param name="right">Right Operand</param>
        /// <returns>Roman numeral</returns>
        public static Roman operator /(Roman left, Roman right)
        {
            int result = Convert.ToInt32(left) / Convert.ToInt32(right);

            return new Roman(Convert.ToRomanString(result));
        }

        /// <summary>
        /// Roman multiplication
        /// </summary>
        /// <param name="left">Left Operand</param>
        /// <param name="right">Right Operand</param>
        /// <returns>Roman numeral</returns>
        public static Roman operator *(Roman left, Roman right)
        {
            int result = Convert.ToInt32(left) * Convert.ToInt32(right);

            return new Roman(Convert.ToRomanString(result));
        }

        /// <summary>
        /// Roman Equals check
        /// </summary>
        /// <param name="left">Left Operand</param>
        /// <param name="right">Right Operand</param>
        /// <returns>Roman numeral</returns>
        public static bool operator ==(Roman left, Roman right)
        {
           return left.RomanNumeral == right.RomanNumeral;
        }

        /// <summary>
        /// Roman not Equals check
        /// </summary>
        /// <param name="left">Left Operand</param>
        /// <param name="right">Right Operand</param>
        /// <returns>Roman numeral</returns>
        public static bool operator !=(Roman left, Roman right)
        {
            return  left.RomanNumeral != right.RomanNumeral;
        }

       

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}

namespace Math.Roman.Tests
{
    public class RomanTest
    {
        [Theory]
        [InlineData("IV")]
        [InlineData("V")]
        [InlineData("VII")]
        [InlineData("IX")]
        [InlineData("MCCXLIX")]
        [InlineData("MCMXCII")]
        [InlineData("MMMCMXCIX")]
        public void test_roman_number_initialization(string romanNumeral)
        {
          Assert.True(Roman.TryParse(romanNumeral, out _));
        }

        [Theory]
        [InlineData("IIV")]
        [InlineData("IVX")]
        [InlineData("VIXI")]
        [InlineData("XXL")]
        [InlineData("MCQCXLIX")]
        [InlineData("MCIMXCII")]
        [InlineData("MMMCCMXCIX")]
        public void test_invalid_roman_number_initialization(string romanNumeral)
        {
            Assert.False(Roman.TryParse(romanNumeral, out _));
        }


        [Theory]
        [InlineData("III", "IV", "VII")] // 3+4 =7
        [InlineData("XL", "L", "XC")] // 40 + 50 = 90
        [InlineData("LXXVII", "CMLXXVI", "MLIII")] // 77 + 976 = 1053
        [InlineData("MCMLXXVI", "MDCCLXXXII", "MMMDCCLVIII")] // 1976 + 1782 = 3758
        public void test_roman_number_addition(string left, string right, string expectedRoman)
        {
            //Arrange 
            Roman.TryParse(left, out Roman A);
            Roman.TryParse(right, out Roman B);
            Roman.TryParse(expectedRoman, out Roman C);
            //ACT & ASSERT
            Assert.Equal(C.RomanNumeral, (A + B).RomanNumeral);

        }

        [Theory]
        [InlineData("IV", "-", "I", "III")] // 4-1 =3
        [InlineData("MDCCCLXIX", "-", "CDLXVII", "MCDII")] // 1869 - 467  = 1402
        [InlineData("VIII", "/", "II", "IV")] // 8 / 2 = 4
        [InlineData("MMCMLXXXVIII", "/", "XIV", "CCXIII")] // 2988 / 14 = 4
        [InlineData("IV", "*", "V", "XX")] //4 * 5 = 20
        [InlineData("LXXVII", "*", "LI", "MMMCMXXVII")] // 77 * 51 = 3927       
        public void test_roman_number_subtraction(string left, string operation, string right, string expectedRoman)
        {
            //Arrange 
            Roman.TryParse(left, out Roman A);
            Roman.TryParse(right, out Roman B);

            //ACT
            var result = operation switch
            {
                "-" => A - B,
                "/" => A / B,
                "*" => A * B,
                _ => throw new ArgumentOutOfRangeException($"invalid {nameof(operation)}")
            };
           
            Roman.TryParse(expectedRoman, out Roman C);

            //ASSERT
            Assert.Equal(C.RomanNumeral, result.RomanNumeral);
           

        }
    }
}
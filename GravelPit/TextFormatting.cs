namespace GravelPit
{
    public static class TextFormatting
    {
        public static string Format(string input)
        {
            string[] parts = input.Split(',');

            int integerPart = 0;
            decimal decimalPart = 0.00m;

            if (parts.Length >= 1)
            {
                if (int.TryParse(parts[0], out int parsedInteger))
                {
                    integerPart = parsedInteger;
                }
            }

            if (parts.Length == 2)
            {
                if (decimal.TryParse("0," + parts[1], out decimal parsedDecimal))
                {
                    decimalPart = parsedDecimal;
                }
            }

            string formattedIntegerPart = integerPart.ToString();
            string formattedDecimalPart = decimalPart.ToString("0.00").Substring(1);

            return formattedIntegerPart + formattedDecimalPart;
        }
    }
}

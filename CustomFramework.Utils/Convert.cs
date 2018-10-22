using System;
using System.Text.RegularExpressions;

namespace CustomFramework.Utils
{
    public static class Convert
    {
        public static string ToSnakeCase(this string input)
        {
            if (string.IsNullOrEmpty(input)) { return input; }

            var startUnderscores = Regex.Match(input, @"^_+");
            return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2")
                       .ToLower().Replace('ı', 'i');
        }

        public static string FormatCardNumber(string cardNumber)
        {
            var firstDigits = cardNumber.Substring(0, 6);
            var lastDigits = cardNumber.Substring(cardNumber.Length - 4, 4);

            var requiredMask = new String('X', cardNumber.Length - firstDigits.Length - lastDigits.Length);

            var maskedString = string.Concat(firstDigits, requiredMask, lastDigits);
            return Regex.Replace(maskedString, ".{4}", "$0 ");
        }

        public static int? ToNullableInt(this string value)
        {
            if (int.TryParse(value, out var i)) return i;
            return null;
        }

    }
}

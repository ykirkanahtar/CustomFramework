using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace CustomFramework.Utils
{
    public static class ConvertFunctions
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

        public static decimal RoundValue(this decimal value)
        {
            return Math.Round(value, 2, MidpointRounding.ToEven);
        }

        public static string MakeFirstCharUpper(this string value)
        {
            if (value.Length < 2) return value.ToUpper();

            return char.ToUpper(value.First()) + value.Substring(1).ToLower();
        }

        // Convert an object to a byte array
        public static byte[] ObjectToByteArray(this object obj)
        {
            if (obj == null)
                return null;

            var bf = new BinaryFormatter();
            var ms = new MemoryStream();
            bf.Serialize(ms, obj);

            return ms.ToArray();
        }

        // Convert a byte array to an Object
        public static object ByteArrayToObject(this byte[] arrBytes)
        {
            var memStream = new MemoryStream();
            var binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);

            return obj;
        }
    }
}

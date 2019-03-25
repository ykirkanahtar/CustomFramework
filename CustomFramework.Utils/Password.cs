using System;
using System.Linq;
using System.Security.Cryptography;

namespace CustomFramework.Utils
{
    public static class Password
    {
        private static readonly char[] Punctuations = "*_-.".ToCharArray();
        private static readonly char[] UpperCases = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private static readonly char[] LowerCases = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        private static readonly char[] Numerics = "0123456789".ToCharArray();

        public static string Generate(int length, int numberOfNonAlphanumericCharacters)
        {
            if (length < 1 || length > 128)
            {
                throw new ArgumentException(nameof(length));
            }

            if (numberOfNonAlphanumericCharacters > length || numberOfNonAlphanumericCharacters < 0)
            {
                throw new ArgumentException(nameof(numberOfNonAlphanumericCharacters));
            }

            using(var rng = RandomNumberGenerator.Create())
            {
                var byteBuffer = new byte[length];

                rng.GetBytes(byteBuffer);

                var countAlphaNumeric = 0;
                var countUpperCase = 0;
                var countLowerCase = 0;
                var countNumeric = 0;

                var characterBuffer = new char[length];

                for (var iter = 0; iter < length; iter++)
                {
                    var i = byteBuffer[iter] % 66;

                    if (i < 10)
                    {
                        characterBuffer[iter] = (char) ('0' + i);
                        countNumeric++;
                    }
                    else if (i < 36)
                    {
                        characterBuffer[iter] = (char) ('A' + i - 10);
                        countUpperCase++;
                    }
                    else if (i < 62)
                    {
                        characterBuffer[iter] = (char) ('a' + i - 36);
                        countLowerCase++;
                    }
                    else
                    {
                        characterBuffer[iter] = Punctuations[i - 62];
                        countAlphaNumeric++;
                    }
                }

                if (countAlphaNumeric >= numberOfNonAlphanumericCharacters &&
                    countUpperCase >= 1 &&
                    countLowerCase >= 1 &&
                    countNumeric >= 1)
                {
                    return new string(characterBuffer);
                }

                var check1 = 0;
                var check2 = 0;
                var check3 = 0;
                var check4 = 0;

                do
                {

                    if (countAlphaNumeric < numberOfNonAlphanumericCharacters)
                    {
                        int j;
                        var rand = new Random();

                        for (j = 0; j < numberOfNonAlphanumericCharacters - countAlphaNumeric; j++)
                        {
                            int k;
                            do
                            {
                                k = rand.Next(0, length);
                            }
                            while (!char.IsLetterOrDigit(characterBuffer[k]));

                            characterBuffer[k] = Punctuations[rand.Next(0, Punctuations.Length)];
                        }
                    }

                    if (countUpperCase < 1)
                    {
                        var rand = new Random();

                        int k;
                        k = rand.Next(0, length);

                        characterBuffer[k] = UpperCases[rand.Next(0, UpperCases.Length)];
                    }

                    if (countLowerCase < 1)
                    {
                        var rand = new Random();

                        int k;
                        k = rand.Next(0, length);

                        characterBuffer[k] = LowerCases[rand.Next(0, LowerCases.Length)];
                    }

                    if (countNumeric < 1)
                    {
                        var rand = new Random();

                        int k;
                        k = rand.Next(0, length);

                        characterBuffer[k] = Numerics[rand.Next(0, Numerics.Length)];
                    }

                    check1 = characterBuffer.Intersect(Punctuations).Count();
                    check2 = characterBuffer.Intersect(LowerCases).Count();
                    check3 = characterBuffer.Intersect(UpperCases).Count();
                    check4 = characterBuffer.Intersect(Numerics).Count();
                }
                while (check1 < numberOfNonAlphanumericCharacters &&
                    check2 < 1 &&
                    check3 < 1 &&
                    check4 < 1);

                return new string(characterBuffer);
            }
        }
    }
}
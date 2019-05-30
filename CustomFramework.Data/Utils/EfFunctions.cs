using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.Data.Utils
{
    public static class EfFunctions
    {
        public static bool LikeEnd(string matchExpression, string pattern)
        {
            return EF.Functions.Like(matchExpression.ToLower(), $"{pattern.ToLower()}%");
        }

        public static bool LikeStart(string matchExpression, string pattern)
        {
            return EF.Functions.Like(matchExpression.ToLower(), $"%{pattern.ToLower()}");
        }

        public static bool LikeStartAndEnd(string matchExpression, string pattern)
        {
            return EF.Functions.Like(matchExpression.ToLower(), $"%{pattern.ToLower()}%");
        }
    }
}
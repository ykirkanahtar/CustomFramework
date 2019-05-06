using System;

namespace CustomFramework.Utils
{
    public static class Calculate
    {
        public static int GetAge(this DateTime birthdate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthdate.Year;

            if (birthdate > today.AddYears(-age))
                age--;

            return age;
        }

    }
}
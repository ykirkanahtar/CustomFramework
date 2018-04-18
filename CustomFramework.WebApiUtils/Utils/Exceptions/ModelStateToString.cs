using System;
using System.Linq;
using CustomFramework.WebApiUtils.Constants;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CustomFramework.WebApiUtils.Utils.Exceptions
{
    public static class ModelStateToStringConverter
    {
        public static string ModelStateToString(this ModelStateDictionary modelState)
        {
            if (modelState.IsValid)
            {
                throw new ArgumentException(DefaultResponseMessages.ModelStateValidError, nameof(modelState));
            }

            var mState = modelState.SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage).ToArray();

            return string.Join(";", mState);
        }

    }
}
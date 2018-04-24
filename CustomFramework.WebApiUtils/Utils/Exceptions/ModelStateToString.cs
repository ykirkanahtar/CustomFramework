﻿using System;
using System.Collections.Generic;
using System.Linq;
using CustomFramework.WebApiUtils.Constants;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CustomFramework.WebApiUtils.Utils.Exceptions
{
    public static class ModelStateToStringConverter
    {
        public static string ModelStateToString(this ModelStateDictionary modelState, ILocalizationService localizationService)
        {
            if (modelState.IsValid)
            {
                throw new ArgumentException(DefaultResponseMessages.ModelStateValidError, nameof(modelState));
            }

            var modelStateStrings = modelState.SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage).ToArray();

            var newModelStateStrings = new List<string>();

            foreach (var modelStateString in modelStateStrings)
            {
                var localisedModelState = string.Empty;
                var localisedModelStateArray = modelStateString.Split(':');
                foreach (var item in localisedModelStateArray)
                {
                    localisedModelState += $"{localizationService.GetValue(item.Trim())} : ";
                }

                newModelStateStrings.Add(localisedModelState.Remove(localisedModelState.Length - 1, 1));
            }

            return string.Join(";", newModelStateStrings.ToArray());
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using BeTheHero.Essential;
using BeTheHero.Essential.Results;
using Mvc = Microsoft.AspNetCore.Mvc;

namespace BeTheHero.Api.Config
{
    public static class ResultToHttpResultMap
    {
        private static readonly IReadOnlyDictionary<Type, ConversionHandler> Map
            = new Dictionary<Type, ConversionHandler>
        {
            [typeof(CommandValidationResult)] = result => Convert(result as CommandValidationResult),
            [typeof(CreatedResult)] = result => Convert(result as CreatedResult),
        };

        private delegate Mvc.IActionResult ConversionHandler(Result result);

        public static Mvc.IActionResult Convert(Result result)
        {
            Check.NotNull(result, nameof(result));

            if (Map.TryGetValue(result.GetType(), out var action))
            {
                return action(result);
            }

            throw new ArgumentException(
                $"Could not map result of type {result.GetType()} to ActionResult");
        }

        private static Mvc.IActionResult Convert(CommandValidationResult result)
        {
            if (result.Ok)
            {
                return new Mvc.OkResult();
            }

            var errors = result.Errors.Select(error => new
            {
                Name = error.MemberNames.First(),
                Message = error.ErrorMessage,
            });

            return new Mvc.BadRequestObjectResult(new
            {
                Message = "One or more validation errors occurred",
                errors,
            });
        }

        private static Mvc.IActionResult Convert(CreatedResult result)
        {
            return new Mvc.CreatedResult(string.Empty, result.Value);
        }
    }
}

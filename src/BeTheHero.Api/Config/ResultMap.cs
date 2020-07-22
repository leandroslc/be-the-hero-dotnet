using System;
using System.Collections.Generic;
using BeTheHero.Essential;
using BeTheHero.Essential.Results;
using Http = Microsoft.AspNetCore.Mvc;

namespace BeTheHero.Api.Config
{
    public static class ResultMap
    {
        private delegate Http.IActionResult ResultConversion(Result result);

        private static readonly IReadOnlyDictionary<Type, ResultConversion> Map
            = new Dictionary<Type, ResultConversion>
        {
            [typeof(CommandValidationResult)] = (result) => FromCommandValidation(result as CommandValidationResult),
        };

        public static Http.IActionResult GetHttpResult(Result result)
        {
            Check.NotNull(result, nameof(result));

            var type = result.GetType();

            if (Map.TryGetValue(type, out var responseAction))
            {
                return responseAction(result);
            }

            throw new InvalidOperationException("Result to ActionResult mapping not found");
        }

        private static Http.IActionResult FromCommandValidation(CommandValidationResult result)
            => new Http.BadRequestObjectResult(result.Errors);
    }
}

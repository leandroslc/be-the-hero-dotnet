using BeTheHero.Api.Config;
using BeTheHero.Essential.Results;
using Microsoft.AspNetCore.Mvc;

namespace BeTheHero.Api.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected static IActionResult FromResult(Result result)
        {
            return ResultToHttpResultMap.Convert(result);
        }
    }
}

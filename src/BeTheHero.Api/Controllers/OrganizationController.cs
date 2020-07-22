using System.Threading.Tasks;
using BeTheHero.Api.Config;
using BeTheHero.Organizations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BeTheHero.Api.Controllers
{
    [ApiController]
    [Route("org")]
    public class OrganizationController : ControllerBase
    {
        private readonly ILogger<OrganizationController> logger;
        private readonly OrganizationService service;

        public OrganizationController(
            ILogger<OrganizationController> logger,
            OrganizationService service)
        {
            this.logger = logger;
            this.service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrganizationCommand command)
        {
            logger.LogInformation("Creating organization");

            var result = await service.Handle(command);

            return ResultMap.GetHttpResult(result);
        }
    }
}

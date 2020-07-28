using System.Threading.Tasks;
using BeTheHero.Core.Organizations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BeTheHero.Api.Controllers
{
    [Route("org")]
    public class OrganizationController : BaseApiController
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

            return FromResult(result);
        }
    }
}

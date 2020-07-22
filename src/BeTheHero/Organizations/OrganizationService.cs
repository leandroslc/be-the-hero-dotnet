using System.Threading.Tasks;
using BeTheHero.Essential;
using BeTheHero.Essential.Results;

namespace BeTheHero.Organizations
{
    public class OrganizationService
    {
        private readonly IOrganizationRepository repository;

        public OrganizationService(IOrganizationRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result> Handle(CreateOrganizationCommand command)
        {
            Check.NotNull(command, nameof(command));

            var validationResult = command.Validate();

            if (validationResult.NotOk)
            {
                return validationResult;
            }

            var city = new City(command.City, command.State);

            var organization = new Organization(
                name: command.Name,
                email: command.Email,
                phone: command.Phone,
                city);

            await repository.Insert(organization);

            return new CreatedResult(new { organization.Id });
        }
    }
}

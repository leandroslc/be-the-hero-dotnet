using System.Threading.Tasks;
using BeTheHero.Essential;
using BeTheHero.Essential.Results;

namespace BeTheHero.Core.Organizations
{
    public class OrganizationService
    {
        private readonly IOrganizationRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public OrganizationService(
            IOrganizationRepository repository,
            IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateOrganizationCommand command)
        {
            command ??= new CreateOrganizationCommand();

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
            await unitOfWork.Commit();

            return new CreatedResult(new { organization.Id });
        }
    }
}

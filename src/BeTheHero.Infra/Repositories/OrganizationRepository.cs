using System.Threading.Tasks;
using BeTheHero.Core.Organizations;
using Microsoft.EntityFrameworkCore;

namespace BeTheHero.Infra.Repositories
{
    public class OrganizationRepository : BaseRepository, IOrganizationRepository
    {
        public OrganizationRepository(BeTheHeroContext context)
            : base(context)
        {
        }

        public async Task Insert(Organization organization)
        {
            await Context.AddAsync(organization);
        }
    }
}

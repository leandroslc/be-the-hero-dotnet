using System.Threading.Tasks;

namespace BeTheHero.Core.Organizations
{
    public interface IOrganizationRepository
    {
        Task Insert(Organization organization);
    }
}

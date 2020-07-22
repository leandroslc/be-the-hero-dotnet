using System.Threading.Tasks;

namespace BeTheHero.Organizations
{
    public interface IOrganizationRepository
    {
        Task Insert(Organization organization);
    }
}

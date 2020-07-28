using System.Threading.Tasks;

namespace BeTheHero.Essential
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}

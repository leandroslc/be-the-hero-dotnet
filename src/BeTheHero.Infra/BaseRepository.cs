using Microsoft.EntityFrameworkCore;

namespace BeTheHero.Infra
{
    public abstract class BaseRepository
    {
        public BaseRepository(DbContext context)
        {
            Context = context;
        }

        protected DbContext Context { get; }
    }
}

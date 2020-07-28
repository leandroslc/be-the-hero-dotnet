using System;
using System.Threading.Tasks;
using BeTheHero.Core.Organizations;
using BeTheHero.Essential;
using Microsoft.EntityFrameworkCore;

namespace BeTheHero.Infra
{
    public class BeTheHeroContext : DbContext, IUnitOfWork
    {
        private readonly Action<DbContextOptionsBuilder> optionsBuilder;

        public BeTheHeroContext(Action<DbContextOptionsBuilder> optionsBuilder)
            : base()
        {
            Check.NotNull(optionsBuilder, nameof(optionsBuilder));

            this.optionsBuilder = optionsBuilder;
        }

        public async Task Commit()
        {
            await SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            optionsBuilder(options);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<Organization>();
            builder.Owned<City>();
        }
    }
}

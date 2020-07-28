using BeTheHero.Core.Organizations;
using BeTheHero.Essential;
using BeTheHero.Infra;
using BeTheHero.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BeTheHero.Api.Config
{
    public static class InfrastructureServices
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<OrganizationService>();
            services.AddScoped((provider) => CreateBeTheHeroContext());
            services.AddScoped<IUnitOfWork>((provider) => CreateBeTheHeroContext());
        }

        private static BeTheHeroContext CreateBeTheHeroContext()
        {
            return new BeTheHeroContext(options =>
            {
                options.UseInMemoryDatabase("be-the-hero");
            });
        }
    }
}

using Mattis.Api.Main.Db.DbContexts;
using Mattis.Api.Main.Db.Repository;
using Mattis.Api.Main.Db.Repository.Implementations;
using Mattis.Api.Main.Db.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Mattis.Api.Main.Db
{
    public static class DbRegisterExtension
    {
        public static void RegisterMainDbContainer(this IServiceCollection services)
        {
            services.AddScoped<IApiMainUnitOfWork, ApiMainUnitOfWork>();
            services.AddScoped<IApiMainDbContext, ApiMainDbContext>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
        }
    }
}
using ApiTest.Data.DbContexts;
using ApiTest.Db.DbContexts;
using ApiTest.Db.Repository.Implementation;
using ApiTest.Db.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace ApiTest.Db
{
    public static class DbRegisterExtension
    {
        public static void RegisterApiTestDbContainer(this IServiceCollection services)
        {
            services.AddScoped<IApiTestDbContext, ApiTestDbContext>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IApiTestUnitOfWork, ApiTestUnitOfWork>();
        }
    }
}

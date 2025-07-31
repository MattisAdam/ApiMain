using ApiTest.Data.DbContexts;
using ApiTest.Db.DbContexts;
using ApiTest.Db.Repository.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace ApiTest.Db
{
    public static class DbRegisterExtension
    {
        public static void RegisterApiTestDbContainer(this IServiceCollection services)
        {
            services.AddScoped<IPersonDbContext, PersonDbContext>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            //services.AddScoped<IBaseUnitofwork, BaseUnitofwork>();
        }
    }
}

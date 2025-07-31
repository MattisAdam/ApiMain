using ApiTest.Data.DbContexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ApiTest.Db.DbContexts;

namespace ApiTest.Db
{
    public static class DbConfigurationExtension
    {
        public static void AddApiTestDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApiTestDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ApiTestDb"),
            o =>
            {
                o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery).UseRelationalNulls();
                o.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
            }));
        }
    }
}

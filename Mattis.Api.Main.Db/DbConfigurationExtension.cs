using Mattis.Api.Main.Db.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mattis.Api.Main.Db
{
    public static class DbConfigurationExtension
    {
        public static void AddApiMainDbContext(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ApiMainDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MattisMainDb"),
                o =>
                {
                    o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery).UseRelationalNulls();
                    o.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                }));
        }
    }
}
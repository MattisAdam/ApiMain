using Mattis.Api.Main.Model;
using Mattis.Core.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Mattis.Api.Main.Db.DbContexts
{
    internal class ApiMainDbContext : BaseDbContext, IApiMainDbContext
    {
        public ApiMainDbContext(DbContextOptions<ApiMainDbContext> options) : base(options)
        {
        }

        public DbSet<PlayerDao> PlayerDbSet { get; set; }

    }
}
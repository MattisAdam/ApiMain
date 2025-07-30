using Mattis.Api.Main.Model;
using Mattis.Core.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Mattis.Api.Main.Db.DbContexts
{
    public interface IApiMainDbContext : IBaseDbContext
    {
        public DbSet<PlayerDao> PlayerDbSet { get; set; }

    }
}
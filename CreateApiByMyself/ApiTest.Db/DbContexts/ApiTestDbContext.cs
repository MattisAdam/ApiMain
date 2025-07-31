using ApiTest.Data.DbContexts;
using ApiTest.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Db.DbContexts
{
    public class ApiTestDbContext : BaseDbContext, IApiTestDbContext
    {
        public ApiTestDbContext(DbContextOptions<ApiTestDbContext> options) : base(options)
        { 
        }

        public DbSet<PersonDao> PersonDbSet { get; set; }
    }
}

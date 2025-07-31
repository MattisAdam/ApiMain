using ApiTest.Data.DbContexts;
using ApiTest.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Db.DbContexts
{
    public interface IApiTestDbContext : IBaseDbContext
    {
        public DbSet<PersonDao> PersonDbSet { get; set; }
    }
}

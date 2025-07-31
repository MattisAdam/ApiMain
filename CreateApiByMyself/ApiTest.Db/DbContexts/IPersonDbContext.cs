using ApiTest.Data.DbContexts;
using ApiTest.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Db.DbContexts
{
    public interface IPersonDbContext : IBaseDbContext
    {
        public DbSet<PersonDao> PersonDbSet { get; set; }
    }
}

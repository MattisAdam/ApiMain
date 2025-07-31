using ApiTest.Data.DbContexts;
using ApiTest.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Db.DbContexts
{
    public class PersonDbContext : BaseDbContext, IPersonDbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        { 
        }

        public DbSet<PersonDao> PersonDbSet { get; set; }
    }
}

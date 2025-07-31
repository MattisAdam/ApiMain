using ApiTest.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace ApiTest.Data.DbContexts
{
    public class BaseDbContext : DbContext, IBaseDbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }
        public new EntityEntry<TModelDao> Entry<TModelDao>(TModelDao entry) where TModelDao : class, IModelDao
        {
            return base.Entry<TModelDao>(entry);
        }
    }

}

using ApiTest.Data.DbContexts;
using ApiTest.Data.Model;

namespace ApiTest.Data.Repository
{
    public interface IBaseRepository<TContext, TModelDao>
        where TModelDao : class, IModelDao
        where TContext : IBaseDbContext
    {
        TContext _context { get; }

        /* all the task for crud*/
    }
}

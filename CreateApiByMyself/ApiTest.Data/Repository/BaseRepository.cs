using ApiTest.Data.DbContexts;
using ApiTest.Data.Model;

namespace ApiTest.Data.Repository
{
    public class BaseRepository<TContext, TModelDao> : IBaseRepository<TContext, TModelDao>
        where TModelDao : class, IModelDao
        where TContext  : IBaseDbContext
    {
        public TContext _context { get; }
        
        public BaseRepository(TContext context)
        {
            _context = context;
        }


        /*here all the crud method*/
    }
}

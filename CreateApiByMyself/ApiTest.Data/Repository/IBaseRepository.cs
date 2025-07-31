using ApiTest.Data.DbContexts;
using ApiTest.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Data.Repository
{
    public interface IBaseRepository<TContext, TModelDao>
        where TModelDao : class, IModelDao
        where TContext : IBaseDbContext
    {
        TContext _context { get; }

        public async Task<TModelDao> GetByIdAsync(int id, bool withNoTracking = true)
        {
            IQueryable<TModelDao> query = _context.Set<TModelDao>();

            if (withNoTracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }


        /* all the task for crud*/
    }
}

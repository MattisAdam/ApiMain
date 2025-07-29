using Mattis.Api.Main.Db.DbContexts;
using Mattis.Api.Main.Dto;
using Mattis.Api.Main.Model;
using Mattis.Core.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Mattis.Api.Main.Db.Repository.Implementations
{
    public class PlayerRepository : BaseRepository<IApiMainDbContext, PlayerDao>, IPlayerRepository
    {
        public PlayerRepository(IApiMainDbContext context) : base(context) { }

        public async Task<IEnumerable<PlayerDao>?> GetByCriteriaAsync(PlayerCriteria criteria)
        {
            var query = _context.PlayerDbSet.AsNoTracking();

            if (criteria.IsActive.HasValue)
                query = query.Where(x => x.IsActive == criteria.IsActive.Value);

            if (!string.IsNullOrWhiteSpace(criteria.FilterText))
                query = query.Where(x => x.Pseudo.Contains(criteria.FilterText));

            return await query.ToListAsync();
        }
    }
}
using Mattis.Api.Main.Db.DbContexts;
using Mattis.Api.Main.Dto;
using Mattis.Api.Main.Model;
using Mattis.Core.Data.Repository;

namespace Mattis.Api.Main.Db.Repository
{
    public interface IPlayerRepository : IBaseRepository<IApiMainDbContext, PlayerDao>
    {
        Task<IEnumerable<PlayerDao>?> GetByCriteriaAsync(PlayerCriteria criteria);
    }
}
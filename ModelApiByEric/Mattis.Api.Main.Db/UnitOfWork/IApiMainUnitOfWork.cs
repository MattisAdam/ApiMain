using Mattis.Api.Main.Db.DbContexts;
using Mattis.Api.Main.Db.Repository;

namespace Mattis.Api.Main.Db.UnitOfWork
{
    public interface IApiMainUnitOfWork
    {
        IApiMainDbContext Context { get; }
        IPlayerRepository PlayerRepository { get; }
        Task<int> SaveChangesAsync();
    }
}

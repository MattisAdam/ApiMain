using Mattis.Api.Main.Db.DbContexts;
using Mattis.Api.Main.Db.Repository;

namespace Mattis.Api.Main.Db.UnitOfWork
{
    internal class ApiMainUnitOfWork : IApiMainUnitOfWork
    {
        public IApiMainDbContext Context { get; }
        public IPlayerRepository PlayerRepository { get; }

        public ApiMainUnitOfWork(
            IApiMainDbContext context,
            IPlayerRepository playerRepository)
        {
            Context = context;
            PlayerRepository = playerRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }

    }
}

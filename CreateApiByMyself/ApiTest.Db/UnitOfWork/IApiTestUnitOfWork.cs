using ApiTest.Db.DbContexts;
using ApiTest.Db.Repository.Implementation;

namespace ApiTest.Db.UnitOfWork
{
    public interface IApiTestUnitOfWork
    {
        IApiTestDbContext Context { get; }
        IPersonRepository PersonRepository { get; }
        Task<int> SaveChangesAsync();

    }
}

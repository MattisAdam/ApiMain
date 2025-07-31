using ApiTest.Db.DbContexts;
using ApiTest.Db.Repository.Implementation;

namespace ApiTest.Db.UnitOfWork
{
    internal class ApiTestUnitOfWork : IApiTestUnitOfWork
    {
        public IApiTestDbContext Context  { get; }
        public IPersonRepository PersonRepository { get; }


        public ApiTestUnitOfWork(ApiTestDbContext context, IPersonRepository personRepository)
        {
            this.Context = context;
            this.PersonRepository = personRepository;
        }


        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}

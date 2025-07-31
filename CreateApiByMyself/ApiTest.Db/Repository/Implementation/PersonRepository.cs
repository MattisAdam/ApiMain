using ApiTest.Data.Repository;
using ApiTest.Db.DbContexts;
using ApiTest.Model;

namespace ApiTest.Db.Repository.Implementation
{
    class PersonRepository : BaseRepository<IApiTestDbContext, PersonDao>, IPersonRepository
    {
        public PersonRepository(IApiTestDbContext context) : base(context)
        {
        }

        
        /* Add byCriteria*/
    }
}

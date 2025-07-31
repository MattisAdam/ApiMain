using ApiTest.Data.Repository;
using ApiTest.Db.DbContexts;
using ApiTest.Model;

namespace ApiTest.Db.Repository.Implementation
{
    class PersonRepository : BaseRepository<IPersonDbContext, PersonDao>, IPersonRepository
    {
        public PersonRepository(IPersonDbContext context) : base(context)
        {
        }

        
        /* Add byCriteria*/
    }
}

using ApiTest.Data.Repository;
using ApiTest.Db.DbContexts;
using ApiTest.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Db.Repository.Implementation
{
    public interface IPersonRepository : IBaseRepository<IApiTestDbContext, PersonDao>
    {
        //Task<IEnumerable<PersonDao>> GetByCriteriaAsync();
        
        /*add parameters after queries*/
    }
}

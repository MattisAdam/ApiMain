using ApiTest.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTest.Model
{
        [Table("ApiTest_Person")]
        public class PersonDao : IModelDao 
        {
            [Key]
            public int Id { get; set; }
            public string? Name { get; set; }
        }
    
}

using Mattis.Core.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mattis.Api.Main.Model
{
    [Table("MAIN_Player")]
    public class PlayerDao : IModelDao
    {
        [Key]
        public int Id { get; set; }
        public required string Pseudo { get; set; }
        public bool IsActive { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
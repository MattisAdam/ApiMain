namespace Mattis.Api.Main.Dto
{
    public class PlayerInput
    {
        public int Id { get; set; }
        public required string Pseudo { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
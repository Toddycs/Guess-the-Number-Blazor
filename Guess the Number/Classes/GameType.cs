namespace Guess_the_Number.Classes
{
    public enum Variables
    {
        Integer,
        Decimal
    }

    public class GameType
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? AcessKey { get; set; }
        public Variables Type { get; set; }
    }
}

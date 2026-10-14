namespace gameStore.Data.Entities;

public class Game
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public Genre? Genre { get; set; }
    public required string Platform { get; set; }
    public required string Developer { get; set; }
    public int ReleaseYear { get; set; }
    public decimal Price { get; set; }
    public double Rating { get; set; }
    public bool IsMultiplayer { get; set; }
}
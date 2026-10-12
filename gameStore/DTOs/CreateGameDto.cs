namespace gameStore.DTOs;

public class CreateGameDto
{
    public string Name { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public string Platform { get; set; } = string.Empty;
    public string Developer { get; set; } = string.Empty;
    public int ReleaseYear { get; set; }
    public decimal Price { get; set; }
    public double Rating { get; set; }
    public bool IsMultiplayer { get; set; }
}
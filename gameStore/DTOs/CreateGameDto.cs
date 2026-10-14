using System.ComponentModel.DataAnnotations;

namespace gameStore.DTOs;

public record CreateGameDto
(
    [Required] [StringLength(50)] string Name,
    [Required] [StringLength(50)] string Genre,
    [Required] [StringLength(100)] string Platform,
    [Required] [StringLength(100)] string Developer,
    [Required] [Range(1900, 2026)] int ReleaseYear,
    [Required] decimal Price,
    [Range(0, 10)] double Rating,
    [Required] bool IsMultiplayer
);

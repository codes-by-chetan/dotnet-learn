using System.ComponentModel.DataAnnotations;

namespace gameStore.DTOs;

public record UpdateGameDto
(
    [Required] string Name,
    [Required] string Genre,
    [Required] string Platform,
    [Required] string Developer,
    [Required] int ReleaseYear,
    [Required] decimal Price,
    [Required] double Rating,
    [Required] bool IsMultiplayer
);


namespace gameStore.DTOs;

public record GameDto
(
    int Id,
    string Name,
    string Genre,
    string Platform,
    string Developer,
    int ReleaseYear,
    decimal Price,
    double Rating,
    bool IsMultiplayer
);

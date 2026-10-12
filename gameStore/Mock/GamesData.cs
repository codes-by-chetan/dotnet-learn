using gameStore.DTOs;
namespace gameStore.Mock;
public static class GamesData
{
public static readonly List<GameDto> games = new List<GameDto>
{
     new GameDto
    {
        Id = 1,
        Name = "Elden Ring",
        Genre = "Action RPG",
        Platform = "PC",
        Developer = "FromSoftware",
        ReleaseYear = 2022,
        Price = 59.99m,
        Rating = 9.5,
        IsMultiplayer = false
    },
    new GameDto
    {
        Id = 2,
        Name = "Grand Theft Auto V",
        Genre = "Open World",
        Platform = "PC, PlayStation, Xbox",
        Developer = "Rockstar Games",
        ReleaseYear = 2013,
        Price = 29.99m,
        Rating = 9.0,
        IsMultiplayer = true
    },
    new GameDto
    {
        Id = 3,
        Name = "Minecraft",
        Genre = "Sandbox",
        Platform = "PC, Mobile, Console",
        Developer = "Mojang Studios",
        ReleaseYear = 2011,
        Price = 26.95m,
        Rating = 9.2,
        IsMultiplayer = true
    },
    new GameDto
    {
        Id = 4,
        Name = "God of War Ragnarök",
        Genre = "Action Adventure",
        Platform = "PlayStation, PC",
        Developer = "Santa Monica Studio",
        ReleaseYear = 2022,
        Price = 49.99m,
        Rating = 9.4,
        IsMultiplayer = false
    },
    new GameDto
    {
        Id = 5,
        Name = "Forza Horizon 5",
        Genre = "Racing",
        Platform = "PC, Xbox, PlayStation",
        Developer = "Playground Games",
        ReleaseYear = 2021,
        Price = 39.99m,
        Rating = 8.8,
        IsMultiplayer = true
    }
};
}

   

using gameStore.DTOs;
namespace gameStore.Mock;

public static class GamesData
{
    public static readonly List<GameDto> games =
    [
        new (
        1,
        "Elden Ring",
        "Action RPG",
        "PC",
        "FromSoftware",
        2022,
        59.99m,
        9.5,
        false
    ),
    new (
        2,
        "The Legend of Zelda: Breath of the Wild",
        "Action Adventure",
        "Nintendo Switch",
        "Nintendo",
        2017,
        59.99m,
        9.7,
        false
    ),
    new (
        3,
        "Minecraft",
        "Sandbox",
        "PC, Mobile, Console",
        "Mojang Studios",
        2011,
        26.95m,
        9.2,
        true
    ),
    new (
        4,
        "God of War Ragnarök",
        "Action Adventure",
        "PlayStation, PC",
        "Santa Monica Studio",
        2022,
        49.99m,
        9.4,
        false
    ),
    new (
        5,
        "Forza Horizon 5",
        "Racing",
        "PC, Xbox, PlayStation",
        "Playground Games",
        2021,
        39.99m,
        8.8,
        true
    )
    ];


}



using gameStore.DTOs;
using gameStore.Mock;

namespace gameStore.Endpoints;

public static class GameEndpoints
{
    public const string GetGameByIdRouteName = "GetGameById";

    public static void MapGameEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/games");
        var games = GamesData.games;

        group.MapGet("/", () => games);

        group.MapGet("/{id}", (int id) =>
            {
                var game = games.Find(game => game.Id == id);
                if (game is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(game);
            }
        ).WithName(GetGameByIdRouteName);

        group.MapPost("/", (CreateGameDto newGame) =>
        {
            GameDto game = new()
            {
                Id = games.Count + 1,
                Name = newGame.Name,
                Genre = newGame.Genre,
                Platform = newGame.Platform,
                Developer = newGame.Developer,
                ReleaseYear = newGame.ReleaseYear,
                Price = newGame.Price,
                Rating = newGame.Rating,
                IsMultiplayer = newGame.IsMultiplayer
            };
            games.Add(game);

            return Results.CreatedAtRoute(GetGameByIdRouteName, new { id = game.Id }, game);

        });

        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            var index = games.FindIndex(game => game.Id == id);
            if (index == -1)
            {
                return Results.NotFound();
            }
            games[index] = new GameDto()
            {
                Id = id,
                Name = updatedGame.Name,
                Genre = updatedGame.Genre,
                Platform = updatedGame.Platform,
                Developer = updatedGame.Developer,
                ReleaseYear = updatedGame.ReleaseYear,
                Price = updatedGame.Price,
                Rating = updatedGame.Rating,
                IsMultiplayer = updatedGame.IsMultiplayer
            };

            return Results.NoContent();

        });

        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        });

    }
}
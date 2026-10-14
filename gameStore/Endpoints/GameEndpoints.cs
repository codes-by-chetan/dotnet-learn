using gameStore.Data.Context;
using gameStore.Data.Entities;
using gameStore.DTOs;
using Microsoft.EntityFrameworkCore;

namespace gameStore.Endpoints;

public static class GameEndpoints
{
    public const string GetGameByIdRouteName = "GetGameById";

    public static void MapGameEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/games");

        group.MapGet("/", async (GameStoreContext db) =>
            {
                return await db.Games.AsNoTracking().ToListAsync();
            }
        );

        group.MapGet("/{id}", async (int id, GameStoreContext db) =>
            {
                var game = await db.Games.FindAsync(id);
                return game is not null ? Results.Ok(game) : Results.NotFound(); ;
            }
        ).WithName(GetGameByIdRouteName);

        group.MapPost("/", async (CreateGameDto newGame, GameStoreContext db) =>
        {   
            Genre genre = await db.Genres.FirstOrDefaultAsync(g => g.Name == newGame.Genre);
            if (genre is null)
            {
                genre = new Genre { Name = newGame.Genre };
                db.Genres.Add(genre);
                await db.SaveChangesAsync();
            }
            Game game = new()
            {
                Name = newGame.Name,
                Genre = genre,
                Platform = newGame.Platform,
                Developer = newGame.Developer,
                ReleaseYear = newGame.ReleaseYear,
                Price = newGame.Price,
                Rating = newGame.Rating,
                IsMultiplayer = newGame.IsMultiplayer
            };
            db.Games.Add(game);

            await db.SaveChangesAsync(); 

            return Results.CreatedAtRoute(GetGameByIdRouteName, new { id = game.Id }, game);

        });

        group.MapPut("/{id}", async (int id, UpdateGameDto updatedGame, GameStoreContext db) =>
        {
            var game = await db.Games.FindAsync(id);

            if (game == null)
            {
                return Results.NotFound();
            }
            game.Name = 

            return Results.NoContent();

        });

        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        });

    }
}
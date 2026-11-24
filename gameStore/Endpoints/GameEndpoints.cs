using gameStore.Data.Context;
using gameStore.Data.Entities;
using gameStore.Data.Utils;
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
                return await db.Games.Include(g => g.Genre).AsNoTracking().ToListAsync();
            }
        );

        group.MapGet("/{id}", async (int id, GameStoreContext db) =>
            {
                var game = await db.Games.Include(g => g.Genre).FirstOrDefaultAsync(g => g.Id == id);
                return game is not null ? Results.Ok(game) : Results.NotFound(); ;
            }
        ).WithName(GetGameByIdRouteName);

        group.MapPost("/", async (CreateGameDto newGame, GameStoreContext db) =>
        {
            Genre? genre = await db.Genres.FirstOrDefaultAsync(g => g.Name == newGame.Genre);
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
            if (updatedGame.Genre != null)
            {
                Genre? genre = await db.Genres.FirstOrDefaultAsync(g => g.Name == updatedGame.Genre);
                if (genre is null)
                {
                    genre = new Genre { Name = updatedGame.Genre };
                    db.Genres.Add(genre);
                    await db.SaveChangesAsync();
                }
                
            }
            game.PatchFrom(updatedGame, db, "Genre");
            await db.SaveChangesAsync();
            return Results.NoContent();

        });

        group.MapDelete("/{id}", async (int id, GameStoreContext db) =>
        {
            var count = await db.Games.Where(g => g.Id == id ).ExecuteDeleteAsync();
            if (count == 0)
            {
                return Results.NotFound();
            }
            return Results.NoContent();
        });

    }
}
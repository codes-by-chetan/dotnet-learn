using gameStore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace gameStore.Data.Context;

public class GameStoreContext : DbContext
{
    public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options)
    {

    }
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();
}
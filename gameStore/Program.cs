using gameStore.Data.Context;
using gameStore.Endpoints;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<GameStoreContext>(options => options.UseNpgsql(connString));
builder.Services.AddValidation();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGameEndpoints();

app.Run();

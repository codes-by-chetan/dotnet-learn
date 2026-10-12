using gameStore.DTOs;
using gameStore.Endpoints;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGameEndpoints();

app.Run();

using GameStore.Api.Modules;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

const string GetGameEndPointName = "GetName";

List<Game> games = [
    new Game
    {
        Id =Guid.NewGuid(),
        Name = "Street Fighter 2",
        Genre ="Fighting",
        Price =19.99m,
        ReleaseDate= new DateOnly(1992,7,15)
    },
    new Game
    {
        Id =Guid.NewGuid(),
        Name = "FIFA 23",
        Genre ="Sports",
        Price =19.99m,
        ReleaseDate= new DateOnly(1992,7,15)
    },
    new Game
    {
        Id =Guid.NewGuid(),
        Name = "Mortal Kombat X",
        Genre ="Fighting",
        Price =59.99m,
        ReleaseDate= new DateOnly(1992,7,15)
    },
    new Game
    {
        Id =Guid.NewGuid(),
        Name = "Super Mario Bros",
        Genre ="Platforms",
        Price =64.99m,
        ReleaseDate= new DateOnly(1992,7,15)
    }
];

// GET /games
app.MapGet("/games", () => games);

//GET /game byId
app.MapGet("/games/{id}", (Guid id) =>
{
    Game? game = games.Find(game => game.Id == id);

    return game is null ? Results.NotFound() : Results.Ok(game);
}).WithName(GetGameEndPointName);

//POST /games
app.MapPost("/games", (Game game) =>
{
    game.Id = Guid.NewGuid();
    games.Add(game);

    return Results.CreatedAtRoute(
        GetGameEndPointName,
        new { id = game.Id },
        game);
});



app.Run();

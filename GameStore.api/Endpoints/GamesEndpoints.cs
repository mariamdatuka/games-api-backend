using GameStore.api.Entities;

namespace GameStore.api.Endpoints;
public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

    static List<Game> games = new()
{
   new Game(){
Id=1,
Name="Street Fighte",
Genre="Fighting",
Price=19.99M,
ReleaseDate=new DateTime(1991,2,1),
ImageUri="https://placehold.co/100",
},
   new Game(){
Id=2,
Name="Fuck Life",
Genre="Horror",
Price=19.90M,
ReleaseDate=new DateTime(1997,2,1),
ImageUri="https://placehold.co/100",
},
   new Game(){
Id=3,
Name="Street Art",
Genre="Drama",
Price=29.99M,
ReleaseDate=new DateTime(1999,2,1),
ImageUri="https://placehold.co/100",
}
};
    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {

        var group = routes.MapGroup("/games").WithParameterValidation();
        group.MapGet("/", () => games);
        group.MapGet("/{id}", (int id) =>
        {
            Game? game = games.Find(game => game.Id == id);
            if (game is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(game);
        }).WithName(GetGameEndpointName);

        group.MapPost("/", (Game game) =>
        {
            game.Id = games.Max(game => game.Id) + 1;
            games.Add(game);
            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
        });

        group.MapPut("/{id}", (int id, Game updatedGame) =>
        {
            Game? existingGame = games.Find(game => game.Id == id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }
            existingGame.Name = updatedGame.Name;
            existingGame.Genre = updatedGame.Genre;
            existingGame.Price = updatedGame.Price;
            existingGame.ReleaseDate = updatedGame.ReleaseDate;
            existingGame.ImageUri = updatedGame.ImageUri;
            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) =>
        {
            Game? game = games.Find(game => game.Id == id);
            if (game is not null)
            {
                games.Remove(game);
            }
            return Results.NoContent();
        });
        return group;
    }
}
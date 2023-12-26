using GameStore.api.Entities;

List<Game> games = new()
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

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/games", () => games);
app.MapGet("/games/{id}", (int id) =>
{
    Game? game = games.Find(game => game.Id == id);
    if (game is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(game);
});

app.Run();

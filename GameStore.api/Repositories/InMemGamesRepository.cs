using GameStore.api.Entities;

namespace GameStore.api.Repositories;

public class InMemGamesRepository : IGamesRepository
{
    private readonly List<Game> games = new()
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
    public IEnumerable<Game> GetAll()
    {
        return games;
    }

    public Game? Get(int id)
    {
        return games.Find(game => game.Id == id);
    }

    public void Create(Game game)
    {
        game.Id = games.Max(game => game.Id) + 1;
        games.Add(game);
    }
    public void Update(Game updatedGame)
    {
        var index = games.FindIndex(game => game.Id == updatedGame.Id);
        games[index] = updatedGame;
    }
    public void Delete(int id)
    {
        var index = games.FindIndex(game => game.Id == id);
        games.RemoveAt(index);

    }
}
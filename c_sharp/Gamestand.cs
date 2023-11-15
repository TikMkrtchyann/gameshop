namespace game;

public class GameStand
{
    private int _id;
    public List<Game> stands = new List<Game>
    {
        new Game("Ddum", "Stealth", 32, "Windows"),
        new Game("NFS", "Racing", 12, "PS5")
    };

    public GameStand(int id) 
    { 
        _id = id; 
    }

    public int GetId()
    {
        return _id;
    }

    public void AddGame(Game game)
    {
        stands.Add(game);
    }

    public void RemoveGame(Game game)
    { 
        stands.Remove(game);
    }

    public void PrintGames()
    {
        Console.WriteLine($"Games in GameStand {_id}:");
        foreach (var game in stands)
        {
            Console.WriteLine($"Name: {game.Name}");
        }
        Console.WriteLine();
    }
}
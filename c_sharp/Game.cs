namespace game;

public class Game
{
    public string Name { get; set; }
    public string Genre { get; set; }
    public int Size { get; set; }
    public string Platform { get; set; }
    
    public Game(string name, string genre, int size, string platform)
    {
        Name = name;
        Genre = genre;
        Size = size;
        Platform = platform;
    }

    public Game() { }

}
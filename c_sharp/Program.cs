// kan tarber stender
// amen mi stendi vra konkret janri xaxer (kareliya avelacnel ev shatacnel)
// xaxery dasavorvum en yst: janr, size, platforma
// et stenderi vra ylnuma xaxy vercnel, dnel
// ka xax hanel-dnelu method, xaxi masin infon tpelu method
// boxk

using game;
using c_sharp.Enums;

void AddGame(GameStand stand)
{

    Console.WriteLine("Enter game's name: ");
    string name = Console.ReadLine();
    Console.WriteLine("Enter game`s genre: ");
    string genre = Console.ReadLine();
    Console.WriteLine("Enter game's size: ");
    int size = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter game`s platform: ");
    string platform = Console.ReadLine();

    Game game = new Game(name, genre, size, platform);
    stand.AddGame(game);
}

void RemoveGame(GameStand stand)
{
    Console.WriteLine("Enter game name: ");
    string name = Console.ReadLine();

    // Create a copy of the stands list to avoid modifying it during iteration
    List<Game> copyOfGames = new List<Game>(stand.stands);

    foreach (Game game in copyOfGames)
    {
        if (game.Name == name)
        {
            stand.RemoveGame(game);
        }
    }
}

var gamestand1 = new GameStand(1);
var gamestand2 = new GameStand(2);
var gamestand3 = new GameStand(3);

List<GameStand> gameStandList = new List<GameStand>();
gameStandList.AddRange(new List<GameStand>() { gamestand1, gamestand2, gamestand3 });

// get GameStandID
Console.WriteLine("Enter stand id");
int standID = int.Parse(Console.ReadLine());
var selectedGameStand = gameStandList.SingleOrDefault(boxk => boxk.GetId() == standID);
if (selectedGameStand == null)
{
    Console.WriteLine("hell nah");
    return;
}

Console.WriteLine("Add or Remove? (1 or 2)");
int choice = int.Parse(Console.ReadLine());
switch (choice)
{
    case 1: AddGame(selectedGameStand); break;
    case 2: RemoveGame(selectedGameStand); break;
    default: Console.WriteLine("switch error"); break;

}

selectedGameStand.PrintGames();






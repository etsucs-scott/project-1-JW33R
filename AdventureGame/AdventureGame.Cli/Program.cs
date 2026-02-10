using AdventureGame.Core;
namespace AdventureGame.Cli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Maze maze = new();
            Player player = new();
            Console.Title = "Adventure Game";
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Press any key to start the game...");
            var movement = Console.ReadKey();
            Console.Clear();
            maze.GenerateMaze();
            maze.PrintMaze();
            while (maze.Alive) 
            {
                movement = Console.ReadKey();
                Console.Clear();
                maze.MovePlayer(movement);
                Console.Clear();
                maze.PrintMaze();
                Console.WriteLine($"Health: {maze.CheckPlayerHealth()}");
            }
        }
    }
}

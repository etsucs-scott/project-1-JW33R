using AdventureGame.Core;
namespace AdventureGame.Cli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Maze maze = new();
            Weapon weapon = new();
            Player player = new();
            maze.ConsoleSpecs();
            Console.WriteLine("Press any key to start the game...");
            var movement = Console.ReadKey();
            Console.Clear();
            maze.GenerateMaze();
            maze.PrintMaze();
            while (maze.alive) 
            {
                movement = Console.ReadKey();
                Console.Clear();
                maze.MovePlayer(movement);
                Console.Clear();
                maze.PrintMaze();
                //Console.WriteLine($"Damage: {weapon.GetDamage()}");
            }
        }
    }
}

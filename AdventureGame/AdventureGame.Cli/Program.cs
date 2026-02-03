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
            maze.GenerateMaze();
            bool alive = true;
            maze.PrintMaze();
            var movement = Console.ReadKey();
            while (alive) 
            {
                movement = Console.ReadKey();
                maze.MovePlayer(movement);
                Console.Clear();
                maze.PrintMaze();
                Console.WriteLine($"Damage: {weapon.GetDamage()}");
            }
        }
    }
}

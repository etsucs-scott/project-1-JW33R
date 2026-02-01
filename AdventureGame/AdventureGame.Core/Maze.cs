using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public class Maze
    {
        public string[,] maze = new string[10, 10];
        public string[,] GenerateMaze()
        {
            int x, y;
            Random random = new Random();
            x = random.Next(10, 20);
            maze = new string[x, x];
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                maze[0, i] = "#";
                maze[i, 0] = "#";
                maze[i, maze.GetLength(0) - 1] = "#";
                maze[maze.GetLength(0) - 1, i] = "#";
            }
            AddMonster();
            AddWeapon();
            AddPotion();
            AddBlankSpace();
            return maze;
        }

        public string[,] AddBlankSpace()
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(0); j++)
                {
                    if (maze[i, j] == null) 
                    {
                        maze[i, j] = ".";
                    }
                }
            }
            return maze;
        }
        public string[,] AddMonster()
        {
            Random random = new Random();
            int x, y;
            int spawnRate = random.Next(1, 10);
            for (int i = 0; i < spawnRate; i++)
            {
                x = random.Next(0, maze.GetLength(0) - 1);
                y = random.Next(0, maze.GetLength(0) - 1);
                if (maze[x, y] == null)
                {
                    maze[x, y] = "M";
                }
                
            }
            return maze;
        }

        public string[,] AddWeapon()
        {
            Random random = new Random();
            int x, y;
            int spawnRate = random.Next(1, 10);
            for (int i = 0; i < spawnRate; i++)
            {
                x = random.Next(0, maze.GetLength(0) - 1);
                y = random.Next(0, maze.GetLength(0) - 1);
                if (maze[x, y] == null)
                {
                    maze[x, y] = "W";
                }
            }
            return maze;
        }

        public string[,] AddPotion()
        {
            Random random = new Random();
            int x, y;
            int spawnRate = random.Next(3, 10);
            for (int i = 0; i < spawnRate; i++)
            {
                x = random.Next(0, maze.GetLength(0) - 1);
                y = random.Next(0, maze.GetLength(0) - 1);
                if (maze[x, y] == null)
                {
                    maze[x, y] = "P";
                }
            }
            return maze;
        }
        public void PrintMaze()
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(0); j++)
                {
                    Console.Write($"[{maze[i, j]}]");
                }
               Console.WriteLine();
            }
        }
        

    }
}

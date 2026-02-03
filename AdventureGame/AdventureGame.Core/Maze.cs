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
        Weapon weapon = new();
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
            AddWalls();
            AddBlankSpace();
            maze[maze.GetLength(0) - 2, maze.GetLength(0) - 2] = "E";   
            maze[2, 2] = "@";
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

        public string[,] AddWalls()
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
                    maze[x, y] = "#";
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

        public bool CheckWeapon()
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(0); j++)
                {
                    if (maze[i, j] == "W")
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public string[,] MovePlayer(ConsoleKeyInfo x)
        {
            if (CheckWeapon())
            {
                weapon.ModifyDamage();
            }
            if (x.Key == ConsoleKey.D || x.Key == ConsoleKey.RightArrow)
            {
                for (int i = 0; i < maze.GetLength(0); i++)
                {
                    for (int j = 0; j < maze.GetLength(0); j++)
                    {
                        if (maze[i, j] == "@")
                        {
                            if (maze[i, j + 1] == "#")
                            {
                                Console.WriteLine("You hit a wall!");
                                continue;
                            }
                            else
                            {
                                maze[i, j] = ".";
                                j += 1;
                                maze[i, j] = "@";
                            }
                        }
                    }
                }
            }
            else if (x.Key == ConsoleKey.A || x.Key == ConsoleKey.LeftArrow)
            {
                for (int i = 0; i < maze.GetLength(0); i++)
                {
                    for (int j = 0; j < maze.GetLength(0); j++)
                    {
                        if (maze[i, j] == "@")
                        {
                            if (maze[i, j - 1] == "#")
                            {
                                Console.WriteLine("You hit a wall!");
                                continue;
                            }
                            else
                            {
                                maze[i, j] = ".";
                                j -= 1;
                                maze[i, j] = "@";
                            }
                            
                        }
                    }
                }
            }
            else if (x.Key == ConsoleKey.S || x.Key == ConsoleKey.DownArrow)
            {
                for (int i = 0; i < maze.GetLength(0); i++)
                {
                    for (int j = 0; j < maze.GetLength(0); j++)
                    {
                        if (maze[i, j] == "@")
                        {
                            if (maze[i + 1, j] == "#")
                            {
                                Console.WriteLine("You hit a wall!");
                                continue;
                            }
                            else
                            {
                                maze[i, j] = ".";
                                i += 1;
                                maze[i, j] = "@";
                            }
                           
                        }
                    }
                }
            }
            else if (x.Key == ConsoleKey.W || x.Key == ConsoleKey.UpArrow)
            {
                for (int i = 0; i < maze.GetLength(0); i++)
                {
                    for (int j = 0; j < maze.GetLength(0); j++)
                    {
                        if (maze[i, j] == "@")
                        {
                            if (maze[i - 1, j] == "#")
                            {
                                Console.WriteLine("You hit a wall!");
                                continue;
                            }
                            else
                            {
                                maze[i, j] = ".";
                                i -= 1;
                                maze[i, j] = "@";
                            }
                        }
                    }
                }
            }
            return maze;
        }
        

    }
}

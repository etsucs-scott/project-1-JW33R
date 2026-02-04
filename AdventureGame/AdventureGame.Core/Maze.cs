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
        Potion potion = new();
        public bool gameWin = false;
        public bool alive = true;

        public void ConsoleSpecs()
        {
            Console.Title = "Adventure Game";
            Console.BackgroundColor = ConsoleColor.DarkBlue;
        }
        public void GenerateMaze()
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
        }

        public void AddBlankSpace()
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
        }
        public void AddMonster()
        {
            Random random = new Random();
            int x, y;
            int spawnRate = random.Next(7, 10);
            for (int i = 0; i < spawnRate; i++)
            {
                x = random.Next(0, maze.GetLength(0) - 1);
                y = random.Next(0, maze.GetLength(0) - 1);
                if (maze[x, y] == null)
                {
                    maze[x, y] = "M";
                }
                
            }
        }

        public void AddWalls()
        {
            Random random = new Random();
            int x, y;
            int spawnRate = random.Next(10, 20);
            for (int i = 0; i < spawnRate; i++)
            {
                x = random.Next(0, maze.GetLength(0) - 4);
                y = random.Next(0, maze.GetLength(0) - 4);
                if (maze[x, y] == null)
                {
                    maze[x, y] = "#";
                }

            }
        }
        public void AddWeapon()
        {
            Random random = new Random();
            int x, y;
            int spawnRate = random.Next(7, 10);
            for (int i = 0; i < spawnRate; i++)
            {
                x = random.Next(0, maze.GetLength(0) - 1);
                y = random.Next(0, maze.GetLength(0) - 1);
                if (maze[x, y] == null)
                {
                    maze[x, y] = "W";
                }
            }
        }

        public void AddPotion()
        {
            Random random = new Random();
            int x, y;
            int spawnRate = random.Next(7, 10);
            for (int i = 0; i < spawnRate; i++)
            {
                x = random.Next(0, maze.GetLength(0) - 1);
                y = random.Next(0, maze.GetLength(0) - 1);
                if (maze[x, y] == null)
                {
                    maze[x, y] = "P";
                }
            }
        }
        public void PrintMaze()
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(0); j++)
                {
                    Console.Write($"{maze[i, j]}");
                }
               Console.WriteLine();
            }
        }

        public bool CheckWeapon(int i, int j)
        {
            if (maze[i, j] == "W")
            {
                return true;
            }
            return false;
        }

        public bool CheckMonster(int i, int j) 
        {
            if (maze[i, j] == "M") 
            {
                return true;
            }
            return false;
        }

        public bool CheckPotion(int i, int j)
        {
            if (maze[i, j] == "P")
            {
                return true;
            }
            return false;
        }

        public bool CheckExit(int i, int j)
        {
            if (maze[i, j] == "E")
            {
                return true;
            }
            return false;
        }

        public void CheckConditions(int i, int j)
        {
            if (CheckWeapon(i, j))
            {
                weapon.ModifyDamage();
            }
            else if (CheckMonster(i, j))
            {
                //Logic for combat goes here
                Console.WriteLine("You encountered a monster!");
                Console.ReadLine();
            }
            else if (CheckPotion(i, j)) 
            {
                Console.WriteLine("You found a health potion!");
                Console.ReadLine();
                potion.Heal();

                //Logic for health potion goes here
            }
            else if (CheckExit(i, j))
            {
                Console.WriteLine("You found the exit! You win!");
                Console.ReadLine();
                gameWin = true;
                alive = false;
                //Logic for winning the game goes here
            }
        }
        public void MovePlayer(ConsoleKeyInfo x)
        {
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
                                CheckConditions(i, j + 1);
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
                                CheckConditions(i, j - 1);
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
                                CheckConditions(i + 1, j);
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
                                CheckConditions(i - 1, j);
                                maze[i, j] = ".";
                                i -= 1;
                                maze[i, j] = "@";
                            }
                        }
                    }
                }
            }
        }
        

    }
}

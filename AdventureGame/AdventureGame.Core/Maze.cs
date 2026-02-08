using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public class Maze
    {
        public string[,] MazeArray { get; private set; }
        public bool GameWin { get; private set; } = false;
        public bool Alive { get; private set;} = true;
        public Weapon Weapon { get; private set; }
        public Potion Potion { get; private set; }
        public Player Player { get; private set; }

        public Monster Monster { get; private set; }
        public Maze()
        {
            MazeArray = new string[10, 10];
            Monster = new();
            Weapon = new();
            Potion = new();
            Player = new();
        }

        public void GenerateMaze()
        {
            int x, y;
            Random random = new Random();
            x = random.Next(10, 20);
            MazeArray = new string[x, x];
            for (int i = 0; i < MazeArray.GetLength(0); i++)
            {
                MazeArray[0, i] = "#";
                MazeArray[i, 0] = "#";
                MazeArray[i, MazeArray.GetLength(0) - 1] = "#";
                MazeArray[MazeArray.GetLength(0) - 1, i] = "#";
            }
            AddMonster();
            AddWeapon();
            AddPotion();
            AddWalls();
            AddBlankSpace();
            MazeArray[MazeArray.GetLength(0) - 2, MazeArray.GetLength(0) - 2] = "E";   
            MazeArray[2, 2] = "@";
        }

        public void AddBlankSpace()
        {
            for (int i = 0; i < MazeArray.GetLength(0); i++)
            {
                for (int j = 0; j < MazeArray.GetLength(0); j++)
                {
                    if (MazeArray[i, j] == null) 
                    {
                        MazeArray[i, j] = ".";
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
                x = random.Next(0, MazeArray.GetLength(0) - 1);
                y = random.Next(0, MazeArray.GetLength(0) - 1);
                if (MazeArray[x, y] == null)
                {
                    MazeArray[x, y] = "M";
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
                x = random.Next(0, MazeArray.GetLength(0) - 4);
                y = random.Next(0, MazeArray.GetLength(0) - 4);
                if (MazeArray[x, y] == null)
                {
                    MazeArray[x, y] = "#";
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
                x = random.Next(0, MazeArray.GetLength(0) - 1);
                y = random.Next(0, MazeArray.GetLength(0) - 1);
                if (MazeArray[x, y] == null)
                {
                    MazeArray[x, y] = "W";
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
                x = random.Next(0, MazeArray.GetLength(0) - 1);
                y = random.Next(0, MazeArray.GetLength(0) - 1);
                if (MazeArray[x, y] == null)
                {
                    MazeArray[x, y] = "P";
                }
            }
        }
        public void PrintMaze()
        {
            for (int i = 0; i < MazeArray.GetLength(0); i++)
            {
                for (int j = 0; j < MazeArray.GetLength(0); j++)
                {
                    Console.Write($"{MazeArray[i, j]}");
                }
               Console.WriteLine();
            }
        }

        public bool CheckWeapon(int i, int j)
        {
            if (MazeArray[i, j] == "W")
            {
                return true;
            }
            return false;
        }

        public bool CheckMonster(int i, int j) 
        {
            if (MazeArray[i, j] == "M") 
            {
                return true;
            }
            return false;
        }

        public bool CheckPotion(int i, int j)
        {
            if (MazeArray[i, j] == "P")
            {
                return true;
            }
            return false;
        }

        public bool CheckExit(int i, int j)
        {
            if (MazeArray[i, j] == "E")
            {
                return true;
            }
            return false;
        }

        public void CheckConditions(int i, int j)
        {
            if (CheckWeapon(i, j))
            {
                Weapon.ModifyDamage();
            }
            else if (CheckMonster(i, j))
            {
                //Logic for combat goes here
                Console.WriteLine("You encountered a monster!");
                Console.ReadLine();
                while (Player.Health > 0 && Monster.Health > 0) 
                {
                    Player.Attack(Player.Damage);
                    Monster.Attack(Monster.Damage);
                    Console.WriteLine($"Your health: {Player.Health}");
                    Console.ReadLine();
                    if (Player.Health <= 0)
                    {
                        Console.WriteLine("You were defeated by the monster! Game over.");
                        Console.ReadLine();
                        Alive = false;
                        break;
                    }
                    else if (Monster.Health <= 0)
                    {
                        Console.WriteLine("You defeated the monster!");
                        Console.ReadLine();
                        break;
                    }
                }
            }
            else if (CheckPotion(i, j)) 
            {
                Console.WriteLine("You found a health potion!");
                Console.ReadLine();
                Player.HealthUp(Potion.Heal);

                //Logic for health potion goes here
            }
            else if (CheckExit(i, j))
            {
                Console.WriteLine("You found the exit! You win!");
                Console.ReadLine();
                GameWin = true;
                Alive = false;
                //Logic for winning the game goes here
            }
        }
        public void MovePlayer(ConsoleKeyInfo x)
        {
            if (x.Key == ConsoleKey.D || x.Key == ConsoleKey.RightArrow)
            {
                for (int i = 0; i < MazeArray.GetLength(0); i++)
                {
                    for (int j = 0; j < MazeArray.GetLength(0); j++)
                    {
                        if (MazeArray[i, j] == "@")
                        {
                            if (MazeArray[i, j + 1] == "#")
                            {
                                Console.WriteLine("You hit a wall!");
                                continue;
                            }
                            else
                            {
                                CheckConditions(i, j + 1);
                                MazeArray[i, j] = ".";
                                j += 1;
                                MazeArray[i, j] = "@";
                            }
                        }
                    }
                }
            }
            else if (x.Key == ConsoleKey.A || x.Key == ConsoleKey.LeftArrow)
            {
                for (int i = 0; i < MazeArray.GetLength(0); i++)
                {
                    for (int j = 0; j < MazeArray.GetLength(0); j++)
                    {
                        if (MazeArray[i, j] == "@")
                        {
                            if (MazeArray[i, j - 1] == "#")
                            {
                                Console.WriteLine("You hit a wall!");
                                continue;
                            }
                            else
                            {
                                CheckConditions(i, j - 1);
                                MazeArray[i, j] = ".";
                                j -= 1;
                                MazeArray[i, j] = "@";
                            }
                            
                        }
                    }
                }
            }
            else if (x.Key == ConsoleKey.S || x.Key == ConsoleKey.DownArrow)
            {
                for (int i = 0; i < MazeArray.GetLength(0); i++)
                {
                    for (int j = 0; j < MazeArray.GetLength(0); j++)
                    {
                        if (MazeArray[i, j] == "@")
                        {
                            if (MazeArray[i + 1, j] == "#")
                            {
                                Console.WriteLine("You hit a wall!");
                                continue;
                            }
                            else
                            {
                                CheckConditions(i + 1, j);
                                MazeArray[i, j] = ".";
                                i += 1;
                                MazeArray[i, j] = "@";
                            }
                           
                        }
                    }
                }
            }
            else if (x.Key == ConsoleKey.W || x.Key == ConsoleKey.UpArrow)
            {
                for (int i = 0; i < MazeArray.GetLength(0); i++)
                {
                    for (int j = 0; j < MazeArray.GetLength(0); j++)
                    {
                        if (MazeArray[i, j] == "@")
                        {
                            if (MazeArray[i - 1, j] == "#")
                            {
                                Console.WriteLine("You hit a wall!");
                                continue;
                            }
                            else
                            {
                                CheckConditions(i - 1, j);
                                MazeArray[i, j] = ".";
                                i -= 1;
                                MazeArray[i, j] = "@";
                            }
                        }
                    }
                }
            }
        }
        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public class Maze
    {
        public object[,] MazeArray { get; private set; }
        public bool GameWin { get; private set; } = false;
        public bool Alive { get; private set;} = true;
        public Weapon Weapon { get; private set; }
        public Potion Potion { get; private set; }
        public Player Player { get; private set; }

        public Monster Monster { get; private set; }
        public Maze()
        {
            MazeArray = new object[10, 10];
            Monster = new(40);
            Weapon = new("Sword", 25);
            Potion = new();
            Player = new();
        }

        public void GenerateMaze()
        {
            int x, y;
            Random random = new Random();
            x = random.Next(10, 20);
            MazeArray = new object[x, x];
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
            int health = random.Next(30, 50);
            Monster monster = new(health);
            for (int i = 0; i < spawnRate; i++)
            {
                health = random.Next(30, 50);
                monster = new(health);
                x = random.Next(0, MazeArray.GetLength(0) - 1);
                y = random.Next(0, MazeArray.GetLength(0) - 1);
                if (MazeArray[x, y] == null)
                {
                    MazeArray[x, y] = monster;
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
                x = random.Next(3, MazeArray.GetLength(0) - 4);
                y = random.Next(3, MazeArray.GetLength(0) - 4);
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

            Weapon Sword = new("Sword", 25);
            Weapon Axe = new("Axe", 15);
            Weapon Bow = new("Bow", 20);
            Weapon Dagger = new("Dagger", 10);
            for (int i = 0; i < 6; i++)
            {
                x = random.Next(0, MazeArray.GetLength(0) - 1);
                y = random.Next(0, MazeArray.GetLength(0) - 1);
                if (MazeArray[x, y] == null)
                {
                    MazeArray[x, y] = Sword;
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
                    Monster.ToString();
                    Weapon.ToString();
                    Console.Write($"{MazeArray[i, j]}");
                }
               Console.WriteLine();
            }
        }

        public bool CheckWeapon(int i, int j)
        {
            if (MazeArray[i, j].GetType() == Weapon.GetType())
            {
                return true;
            }
            return false;
        }

        public bool CheckMonster(int i, int j) 
        {
            if (MazeArray[i, j].GetType() == Monster.GetType()) 
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

        public int CheckPlayerHealth()
        {
            return Player.Health;
        }
        public void CheckConditions(int i, int j)
        {
            if (CheckWeapon(i, j))
            {
                Console.WriteLine(Weapon.PickupMessage(((Weapon)MazeArray[i, j]).NameOfWeapon, ((Weapon)MazeArray[i, j]).Damage));
                Console.ReadLine();
                Player.Inventory.Add((Weapon)MazeArray[i, j]);
                Player.DamageChange(((Weapon)MazeArray[i, j]).Damage);
            }
            else if (CheckMonster(i, j))
            {
                //Logic for combat goes here
                Console.WriteLine("You encountered a monster!");
                Console.ReadLine();
                Monster = (Monster)MazeArray[i, j];
                
                while (Player.Health > 0 && Monster.Health > 0) 
                {
                    Console.WriteLine($"Monster Health: {Monster.Health}");
                    Console.ReadLine();
                    Player.Attack(Player.Damage, Monster);
                    Monster.Attack(Monster.Damage, Player);
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
                Console.WriteLine(Potion.PickupMessage("Potion", 20));
                Console.ReadLine();
                Player.HealthUp(Potion.Heal);
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

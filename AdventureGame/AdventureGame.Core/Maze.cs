using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public class Maze //This class is used to generate the maze, do logic for moving the player, and do battle logic
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

        public void GenerateMaze() //Used to generate all of the elements in the maze including walls, weapons, monsters, potions and the player
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

        public void AddBlankSpace() //Used to fill in the blank spaces where there is no other element
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
        public void AddMonster() //Used to add monsters into the maze with the use of the random class to determine spawn rate and the different health of the monsters
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

        public void AddWalls() //Used to add walls into maze
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
        public void AddWeapon() //Used to add different weapons into the maze
        {
            Random random = new Random();
            Weapon[] weapons = new Weapon[4]
            { 
                new Weapon("Sword", 25), new Weapon("Axe", 15), new Weapon("Bow", 20), new Weapon("Dagger", 10) 
            };
            
            int x, y, z;
            for (int i = 0; i < 6; i++)
            {
                z = random.Next(0, weapons.Length);
                x = random.Next(0, MazeArray.GetLength(0) - 1);
                y = random.Next(0, MazeArray.GetLength(0) - 1);
                if (MazeArray[x, y] == null)
                {
                    MazeArray[x, y] = weapons[z];
                }
            }
        }

        public void AddPotion() //Used to add potions into the maze
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
        public void PrintMaze() //Used to print the maze to the console, uses ToString for the Monster and Weapon classes because instances are stored in the maze instead of just a string
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

        public bool CheckWeapon(int i, int j) //Used to check if there is a weapon in the space the player is trying to move to
        {
            if (MazeArray[i, j].GetType() == Weapon.GetType())
            {
                return true;
            }
            return false;
        }

        public bool CheckMonster(int i, int j) //Used to check if there is a monster in the space the player is trying to move to
        {
            if (MazeArray[i, j].GetType() == Monster.GetType()) 
            {
                return true;
            }
            return false;
        }

        public bool CheckPotion(int i, int j) //Used to check if there is a potion in the space the player is trying to move to
        {
            if (MazeArray[i, j] == "P")
            {
                return true;
            }
            return false;
        }

        public bool CheckExit(int i, int j) //Used to check if there is a exit in the space the player is trying to move to
        {
            if (MazeArray[i, j] == "E")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns the player's current health.
        /// </summary>
        /// <returns>The player's current health</returns>
        public int CheckPlayerHealth() //Used to always get the players health so it can be printed to the console
        {
            return Player.Health;
        }
           /// <summary>
           /// Takes in a spot on the array and checks for all of the conditions used for checking to see if there is an object
           /// </summary>
           /// <param name="i"></param>
           /// <param name="j"></param>
        public void CheckConditions(int i, int j) //Used to check all of the conditions for certain actions to happen and uses the Check methods right before this
        {
            if (CheckWeapon(i, j)) // Checks to see if weapon was true and if is does logic for picking up weapon and changing damage
            {
                Console.WriteLine(Weapon.PickupMessage(((Weapon)MazeArray[i, j]).NameOfWeapon, ((Weapon)MazeArray[i, j]).Damage));
                Player.Inventory.Add((Weapon)MazeArray[i, j]);
                if (((Weapon)MazeArray[i, j]).Damage > Player.Damage)
                {
                    Player.DamageChange(((Weapon)MazeArray[i, j]).Damage);
                    Console.WriteLine($"Your damage has increased to {Player.Damage}!");
                    Console.ReadLine();
                }
                else 
                {
                    Console.WriteLine("Your current weapon is better or the same as this one, so you put the picked up weapon in your inventory.");
                    Console.ReadLine();
                }
            }
            else if (CheckMonster(i, j)) //Checks to see if monster was true and if it is does logic for combat 
            {
                Console.WriteLine("You encountered a monster!");
                Console.ReadLine();
                Monster = (Monster)MazeArray[i, j];
                Console.WriteLine($"Monster Health: {Monster.Health}");

                while (Player.Health > 0 && Monster.Health > 0) 
                {
                    Player.Attack(Player.Damage, Monster);
                    if (Monster.Health < 0)
                    {
                        Console.WriteLine("You defeated the monster!");
                        Console.ReadLine();
                        break;
                    }
                    Console.WriteLine($"Your Turn: ");
                    Console.WriteLine($"You deal: {Player.Damage}");
                    Console.WriteLine($"Monster Health: {Monster.Health}");
                    Console.ReadLine();
                    Monster.Attack(Monster.Damage, Player);
                    Console.WriteLine($"Monsters Turn: ");
                    Console.WriteLine($"The monster deals: {Monster.Damage}");
                    Console.WriteLine($"Your health: {Player.Health}");
                    Console.ReadLine();
                    if (Player.Health <= 0)
                    {
                        Console.WriteLine("You were defeated by the monster! Game over.");
                        Console.ReadLine();
                        Alive = false;
                        break;
                    }
                }
            }
            else if (CheckPotion(i, j)) //Checks to see if potion was true and if it is it does logic for healing the player
            {
                Console.WriteLine(Potion.PickupMessage("Potion", 20));
                Console.ReadLine();
                Player.HealthUp(Potion.Heal);
            }
            else if (CheckExit(i, j)) //Checks to see if the exit was true and if it is it does logic for winning the game
            {
                Console.WriteLine("You found the exit! You win!");
                Console.ReadLine();
                GameWin = true;
                Alive = false;
            }
        }
        public void MovePlayer(ConsoleKeyInfo x) //Does all logic for moving the player 
        {
            if (x.Key == ConsoleKey.D || x.Key == ConsoleKey.RightArrow) //If D or RightArrow is pressed checks for walls and changes the location of player and the spot the player left to a blank space
            {
                for (int i = 0; i < MazeArray.GetLength(0); i++)
                {
                    for (int j = 0; j < MazeArray.GetLength(0); j++)
                    {
                        if (MazeArray[i, j] == "@")
                        {
                            if (j + 2 < MazeArray.GetLength(0))
                            {
                                CheckConditions(i, j + 1);
                                MazeArray[i, j] = ".";
                                j += 1;
                                MazeArray[i, j] = "@";
                            }
                            else
                            {
                                Console.WriteLine("You hit a wall!");
                                Console.ReadLine();
                            }
                        }
                    }
                }
            }
            else if (x.Key == ConsoleKey.A || x.Key == ConsoleKey.LeftArrow) //If A or LeftArrow is pressed checks for walls and changes the location of player and the spot the player left to a blank spac
            {
                for (int i = 0; i < MazeArray.GetLength(0); i++)
                {
                    for (int j = 0; j < MazeArray.GetLength(0); j++)
                    {
                        if (MazeArray[i, j] == "@")
                        {
                            if (j == 1)
                            {
                                Console.WriteLine("You hit a wall!");
                                Console.ReadLine();
                               
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
            else if (x.Key == ConsoleKey.S || x.Key == ConsoleKey.DownArrow) //If S or DownArrow is pressed checks for walls and changes the location of player and the spot the player left to a blank spac
            {
                for (int i = 0; i < MazeArray.GetLength(0); i++)
                {
                    for (int j = 0; j < MazeArray.GetLength(0); j++)
                    {
                        if (MazeArray[i, j] == "@")
                        {
                            if (i + 2 < MazeArray.GetLength(0))
                            {
                                CheckConditions(i + 1, j);
                                MazeArray[i, j] = ".";
                                i += 1;
                                MazeArray[i, j] = "@";
                                
                            }
                            else
                            {
                                Console.WriteLine("You hit a wall!");
                                Console.ReadLine();
                            }
                           
                        }
                    }
                }
            }
            else if (x.Key == ConsoleKey.W || x.Key == ConsoleKey.UpArrow) //If W or UpArrow is pressed checks for walls and changes the location of player and the spot the player left to a blank spac
            {
                for (int i = 0; i < MazeArray.GetLength(0); i++)
                {
                    for (int j = 0; j < MazeArray.GetLength(0); j++)
                    {
                        if (MazeArray[i, j] == "@")
                        {
                            if (i == 1)
                            {
                                Console.WriteLine("You hit a wall!");
                                Console.ReadLine();
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


## Getting Started (CLI)

You may use **Visual Studio**, **VS Code**, or the **terminal**.

### Create a solution
```bash
dotnet new sln -n ProjectName
```

### Create a project (example: console app)
```bash
dotnet new console -n ProjectName.App
```

### Add the project to the solution
```bash
dotnet sln add ProjectName.App
```

### Build and run
```bash
dotnet build


### Movement and Display Format:
To play the game you will use WASD and The arrow keys to move.
@ - Player(You control and move this player)
# - Wall(Can't go past walls)
M - Monster(When encountered, you will engage in a turn based system until either one of you defeated)
P - Potion(Upon pickup heal +20)
W - Weapon(Upon pickup gain a damage boost depending on already equipped weapon)
E - Exit(The goal of the game)
---------------------
These are the different symbols you will encounter in the maze and each have their own role.
The objective of the game is to make it to the Exit. You might have to fight monsters on the way but that is the overall goal.
If defeated by the monster(i.e. your health goes below 0) then you lose the game. If you reach the exit tile, you win.

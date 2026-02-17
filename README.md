
Build and Run:
Type these lines into the terminal:
git clone https://github.com/etsucs-scott/project-1-JW33R.git
cd project-1-JW33R/AdventureGame #Used to get inside of the directory
dotnet restore #Used to install any dependencies if you don't have them
dotnet build
dotnet run
---------------------------------------
To play the game you will use WASD and The arrow keys to move.
W - Up
A - Left 
S - Down
D - Right
-------------------
@ - Player(You control and move this player)
"#" - Wall(Can't go past walls)
M - Monster(When encountered, you will engage in a turn based system until either one of you defeated)
P - Potion(Upon pickup heal +20)
W - Weapon(Upon pickup gain a damage boost depending on already equipped weapon)
E - Exit(The goal of the game)
---------------------
These are the different symbols you will encounter in the maze and each have their own role.
The objective of the game is to make it to the Exit. You might have to fight monsters on the way but that is the overall goal.
If defeated by the monster(i.e. your health goes below 0) then you lose the game. If you reach the exit tile, you win.
----------------------------
UML Diagram: The file is included as "AdventureGame.drawio.png" it shows all the relationships between each class inside of the program
------------
Git Usage:
git clone
git commit -m
git pull
git push

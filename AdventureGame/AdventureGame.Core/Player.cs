using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public class Player
    {

        public List<int> inventory = new();
        public int health = 100;
        public int maxHealth = 150;
        public int damage = 10;
    }
}

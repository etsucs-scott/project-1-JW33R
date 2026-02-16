using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public class Potion : Item //Class used for potions that the player picks up and uses to heal themselves
    {
        public int Heal { get; private set; } = 20;

        public override string PickupMessage(string name, int heal) //Used when the player picks up a potion
        {
           return $"You picked up a {name} that heals {heal} health.";
        }
    }
}

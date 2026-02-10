using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public class Potion : Item
    {
        public int Heal { get; private set; } = 20;

        public override string PickupMessage(string name, int heal)
        {
           return $"You picked up a {name} that heals {heal} health.";
        }
        public override string Name()
        {
            throw new NotImplementedException();
        }
    }
}

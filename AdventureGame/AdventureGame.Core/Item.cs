using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public abstract class Item //Base class for all items in the game
    {
        public abstract string PickupMessage(string x, int y);

    }
}

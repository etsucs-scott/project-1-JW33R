using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public abstract class Item
    {
        public abstract string PickupMessage(string x, int y);

        public abstract string Name();
    }
}

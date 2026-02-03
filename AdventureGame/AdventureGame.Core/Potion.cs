using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    internal class Potion
    {
        int heal = 20;
        public int Heal()
        {
            return heal;
        }

        public void Heal(Player player)
        {
            player.health += heal;
            if (player.health > player.maxHealth)
            {
                player.health = player.maxHealth;
            }
        }
    }
}

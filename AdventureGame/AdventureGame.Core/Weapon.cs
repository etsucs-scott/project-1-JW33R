using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AdventureGame.Core
{
    public class Weapon
    {
        Player player = new();
        public Dictionary<string, int> weaponModifiers = new()
        {
            {"Godly", 30 }, {"Weak", -5 }, {"Strong", 5 }, {"Hurtful", 10 }, {"Slow", -2 }, {"Amazing", 15 }, {"Cool", 7 }, {"Not Cool", -7}
        };

        public void ModifyDamage()
        {
            Random random = new Random();
            int modifierIndex = random.Next(weaponModifiers.Count);
            int modifier = weaponModifiers.ElementAt(modifierIndex).Value;
            foreach (var item in player.inventory)
            {
                if (item != modifier)
                {
                    player.inventory.Add(modifier);
                }
                if (item > modifier)
                {
                    player.damage = modifier;
                }
            }
            player.damage += modifier;
        }
     
    }
}

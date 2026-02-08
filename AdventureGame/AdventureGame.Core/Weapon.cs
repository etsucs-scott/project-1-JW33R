using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AdventureGame.Core
{
    public class Weapon : Item
    {
        Player player = new();
        public string[] weaponNames = new string[8] {"Sword", "Axe", "Bow", "Dagger", "Mace", "Spear", "Hammer", "Staff"};
        public int[] weaponDamage = new int[8] {17, 20, 12, 11, 18, 20, 22, 25};
        public void ModifyDamage()
        {
            Random random = new Random();
            int modifierIndex = random.Next(weaponNames.Length);
            int modifier = weaponDamage[modifierIndex];
            player.Inventory.Add(modifier);
            foreach (var item in player.Inventory)
            {
                if (player.Damage > modifier)
                {
                    break;
                }
                else if (item > player.Damage)
                {
                    player.DamageChange(item);
                }
            }
            Console.WriteLine(player.Damage);
            Console.ReadLine();
        }

    }
}

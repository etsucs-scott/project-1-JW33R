using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AdventureGame.Core
{
    public class Weapon : Item //Class that is used for weapons that the player picks up and uses
    {
        public string NameOfWeapon { get; private set; }
        public int Damage { get; private set; }
        public Weapon(string name, int damage) 
        {
            NameOfWeapon = name;
            Damage = damage;
        }
        public override string ToString() //Used to represent a weapon in the console
        {
            return "W";
        }

        public override string PickupMessage(string weaponName, int damage) //Used when the player picks up a weapon
        {
            return $"You picked up a {weaponName} that does {damage} damage.";
        }


    }
}

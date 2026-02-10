using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AdventureGame.Core
{
    public class Weapon : Item
    {
        public string NameOfWeapon { get; private set; }
        public int Damage { get; private set; }
        public Weapon(string name, int damage) 
        {
            NameOfWeapon = name;
            Damage = damage;
        }
        public override string ToString()
        {
            return "W";
        }

        public override string PickupMessage(string weaponName, int damage)
        {
            return $"You picked up a {weaponName} that does {damage} damage.";
        }

        public override string Name()
        {
            throw new NotImplementedException();
        }

    }
}

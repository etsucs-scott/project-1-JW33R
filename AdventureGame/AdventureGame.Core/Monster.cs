using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public class Monster : ICharacter
    {
        public int Health { get; private set; }
        public int Damage { get; private set; }

        public Monster(int health) 
        {
            Damage = 10;
            Health = health;
        }

        public void TakeDamage(int damage)
        {  
            Health -= damage;
        }

        public void Attack(int damage, ICharacter character)
        {
            character.TakeDamage(damage);
        }

        public override string ToString()
        {
            return "M";
        }
    }
}

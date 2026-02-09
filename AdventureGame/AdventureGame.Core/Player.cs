using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public class Player : ICharacter
    {

        public List<int> Inventory { get; private set; }
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }
        public int Damage { get; private set; } 

        public Monster Monster { get; private set; }

        public Player()
        {
            Health = 100;
            MaxHealth = 150;
            Damage = 10;
            //Monster = new();
        }

        public void DamageChange(int newDamage)
        {
            Damage = newDamage;
        }

        public void HealthUp(int heal) 
        { 
            Health += heal;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }
        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public void Attack(int damage)
        {
            Monster.TakeDamage(damage);
        }
    }

}

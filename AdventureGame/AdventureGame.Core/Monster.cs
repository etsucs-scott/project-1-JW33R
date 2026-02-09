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

        public Player Player { get; private set; }

        public Monster() 
        {
            Player = new Player();
            Damage = 10;
            Health = 30;
        }

        public void TakeDamage(int damage)
        {  
            Health -= damage;
        }

        public void Attack(int damage)
        {
            Player.TakeDamage(damage);
        }
    }
}

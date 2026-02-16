namespace AdventureGame.Core
{
    public interface ICharacter //Interface used for Player and Monster and is used for attacking and taking damage
    {
        public void TakeDamage(int damage);
        public void Attack(int damage, ICharacter character);
    }
}

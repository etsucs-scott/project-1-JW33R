namespace AdventureGame.Core
{
    public interface ICharacter
    {
        public void TakeDamage(int damage);
        public void Attack(int damage, ICharacter character);
    }
}

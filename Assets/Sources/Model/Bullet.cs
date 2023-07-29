namespace Archero.Model
{
    public class Bullet
    {
        private int _damage;

        public Bullet(int damage)
        {
            _damage = damage;
        }

        public void ApplyDamage(Creature creature)
        {
            creature.TakeDamage(_damage);
        }
    }
}
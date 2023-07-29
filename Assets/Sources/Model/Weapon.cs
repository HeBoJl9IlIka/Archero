namespace Archero.Model
{
    public abstract class Weapon
    {
        private Creature _creature;
        private int _damage;

        public Weapon(int damage)
        {
            _damage = damage;
        }

        public void Init(Creature creature)
        {
            _creature = creature;
        }

        public void Attack(IDamageable damageable)
        {
            int damage = _damage + _creature.Damage;
            damageable.TakeDamage(damage);
        }
    }
}

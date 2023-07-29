using System;

namespace Archero.Model
{
    public class Weapon
    {
        private Creature _creature;
        private int _damage;

        public event Action<Creature, int> Shot;

        public Weapon(int damage)
        {
            _damage = damage;
        }

        public void Init(Creature creature)
        {
            _creature = creature;
        }

        public void Attack()
        {
            Shot?.Invoke(_creature, _damage);
        }
    }
}

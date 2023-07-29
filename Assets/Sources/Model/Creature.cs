using UnityEngine;

namespace Archero.Model
{
    public class Creature
    {
        private readonly IHealable _healable;
        private readonly IProtect _protect;
        private readonly Weapon _weapon;
        private readonly TargetSelector _targetSelector;
        private Creature _target;

        public IDamageable Damageable { get; private set; }
        public int Damage { get; private set; }
        public Vector3 Position { get; private set; }

        public Creature(IDamageable damageable, IHealable healable, IProtect protect, Weapon weapon, int damage, TargetSelector targetSelector)
        {
            Damageable = damageable;
            _healable = healable;
            _protect = protect;
            _weapon = weapon;
            Damage = damage;
            _targetSelector = targetSelector;

            _weapon.Init(this);
            _targetSelector.Init(this);
        }

        public void SetPosition(Vector3 position)
        {
            Position = position;
        }

        public void TakeDamage(TypeDamage typeDamage, int value)
        {
            int damage = _protect.AffectDamage(typeDamage, value);
            Damageable.TakeDamage(damage);
        }

        public void TakeHeale(int value)
        {
            _healable.TakeHeale(value);
        }

        public void Attack()
        {
            _weapon.Attack(_target.Damageable);
        }

        public void SetTargets(Creature[] targets)
        {
            _targetSelector.SetTargets(targets);
        }

        public void SelectTarget()
        {
            _targetSelector?.SelectTarget();
        }

        public void SetTraget(Creature creature)
        {
            _target = creature;
        }
    }
}

using System;
using UnityEngine;

namespace Archero.Model
{
    public class Creature
    {
        private readonly Weapon _weapon;
        private readonly TargetSelector _targetSelector;
        private readonly Health _health;
        private Creature _target;

        public bool IsDead => _health.IsDead;

        public float SpeedAttack { get; private set; }
        public Vector3 Position { get; private set; }
        public Vector3 Direction { get; private set; }

        public event Action Died;

        public Creature(Health health, Weapon weapon, TargetSelector targetSelector, float speedAttack)
        {
            _health = health;
            _weapon = weapon;
            _targetSelector = targetSelector;
            SpeedAttack = speedAttack;

            _weapon.Init(this);
            _targetSelector.Init(this);
        }

        public void Enable()
        {
            _health.Died += OnDied;
        }

        public void Disable()
        {
            _health.Died -= OnDied;
        }

        public void SetTargets(Creature[] targets)
        {
            _targetSelector.SetTargets(targets);
        }

        public void SetPosition(Vector3 position)
        {
            Position = position;
        }

        public void TakeDamage(int value)
        {
            _health.TakeDamage(value);
        }

        public bool CanSetDirection()
        {
            _target = _targetSelector.GetTarget();

            if (_target == null)
                return false;

            Direction = _target.Position - Position;

            return _target != null;
        }

        public void CanAttack()
        {
            if(_target == null)
                return;

            _weapon.Attack();
        }

        private void OnDied()
        {
            Died?.Invoke();
        }
    }
}

using System;

namespace Archero.Model
{
    public class Health : IDamageable, IHealable
    {
        private readonly IDiyingPolicy _diyingPolicy;
        private int _maxHealth;

        public int Value { get; private set; }

        private int SpentHealth => _maxHealth - Value;

        public event Action<int> TookDamage;
        public event Action<int> TookHealed;
        public event Action Died;

        public Health(IDiyingPolicy diyingPolicy, int value)
        {
            Value = value;
            _diyingPolicy = diyingPolicy;
        }

        public void TakeDamage(int value)
        {
            if(value <= 0)
                value = 0;

            Value -= value;
            TookDamage?.Invoke(value);

            if (_diyingPolicy.Died(Value))
                Died?.Invoke();
        }

        public void TakeHeale(int value)
        {
            if(value > SpentHealth)
                value = SpentHealth;

            Value += value;
            TookHealed?.Invoke(value);
        }
    }
}
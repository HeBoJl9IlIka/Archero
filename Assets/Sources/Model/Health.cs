using System;

namespace Archero.Model
{
    public class Health
    {
        public bool IsDead => Value <= 0;

        public int Value { get; private set; }

        public event Action<int> TookDamage;
        public event Action Died;

        public Health(int value)
        {
            Value = value;
        }

        public void TakeDamage(int value)
        {
            if(value <= 0)
                value = 0;

            Value -= value;
            TookDamage?.Invoke(value);

            if (IsDead)
                Died?.Invoke();
        }
    }
}
using System;

namespace Archero.Model
{
    public class Wallet
    {
        public int Value { get; private set; }

        public event Action<int> Changed;

        public void AddMoney(int value)
        {
            Value += value;
            Changed?.Invoke(Value);
        }
    }
}

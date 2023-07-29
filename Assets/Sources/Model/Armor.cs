using System;

namespace Archero.Model
{
    public class Armor : IProtect
    {
        private int _melee;
        private int _shooting;

        public event Action Blocked;

        public Armor(int melee, int shooting)
        {
            _melee = melee;
            _shooting = shooting;
        }

        public int AffectDamage(TypeDamage typeDamage, int value)
        {
            int damage = value;

            if (typeDamage == TypeDamage.Melee)
                damage -= _melee;

            if(typeDamage == TypeDamage.Shooting)
                damage -= _shooting;

            if(damage < value)
                Blocked?.Invoke();

            return damage;
        }
    }
}

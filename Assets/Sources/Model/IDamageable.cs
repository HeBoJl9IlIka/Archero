namespace Archero.Model
{
    public enum TypeDamage
    {
        Melee,
        Shooting
    }

    public interface IDamageable
    {
        public void TakeDamage(int value);
    }
}

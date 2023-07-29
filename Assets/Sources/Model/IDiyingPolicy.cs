namespace Archero.Model
{
    public interface IDiyingPolicy
    {
        bool Died(int health);
    }

    public class NormalDiyingPolicy : IDiyingPolicy
    {
        public bool Died(int health)
        {
            return health <= 0;
        }
    }
}
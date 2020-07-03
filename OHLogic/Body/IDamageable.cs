using OHLogic.DataObjects;

namespace OHLogic.Common
{
    public interface IDamageable
    {
        float Health { get; }

        void ReceiveDamage(float damage);
    }
}

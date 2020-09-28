namespace Assets.Common
{
    public interface IDamageable
    {
        float Health { get; }

        void ReceiveDamage(float damage);
    }
}

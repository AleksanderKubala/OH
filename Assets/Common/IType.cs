namespace Assets.Common
{
    public interface IType<in T>
    {
        bool BelongsToType(T type);
    }
}

namespace Assets.Common
{
    public interface IType<T>
    {
        bool BelongsToType(T group);
    }
}

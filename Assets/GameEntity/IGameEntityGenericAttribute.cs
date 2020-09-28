using System;

namespace Assets.GameEntity
{
    public interface IGameEntityGenericAttribute<TValue> : IGameEntityAttribute, IComparable<IGameEntityGenericAttribute<TValue>>, IEquatable<IGameEntityGenericAttribute<TValue>> where TValue : struct, IEquatable<TValue>, IComparable<TValue>
    {
        event EventHandler AttributeValueChanged;

        TValue BaseValue { get; }
        TValue CurrentValue { get; }

        void ChangeBy(TValue change);
        void SetTo(TValue value);
    }
}

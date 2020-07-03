using System;

namespace OHLogic.GameEntity
{
    public abstract class GameEntityGenericAttribute<TValue> : GameEntityAttribute, IGameEntityGenericAttribute<TValue> where TValue : struct, IEquatable<TValue>, IComparable<TValue>
    {
        protected TValue baseValue;

        public GameEntityGenericAttribute(GameEntityGenericAttributeType<TValue> attributeType, TValue baseValue) : base(attributeType)
        {
            this.baseValue = baseValue;
        }

        public event EventHandler AttributeValueChanged;

        public TValue BaseValue => baseValue;
        public abstract TValue CurrentValue { get; }

        public abstract void ChangeBy(TValue change);
        public abstract void SetTo(TValue value);

        public int CompareTo(IGameEntityGenericAttribute<TValue> other)
        {
            return CurrentValue.CompareTo(other.CurrentValue);
        }

        public bool Equals(IGameEntityGenericAttribute<TValue> other)
        {
            var equality = base.Equals(other);

            return equality;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

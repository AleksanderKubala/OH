using System;

namespace Assets.GameEntity
{
    public class GameEntityGenericAttributeType<TValue> : GameEntityAttributeType, IEquatable<GameEntityGenericAttributeType<TValue>> where TValue : struct, IEquatable<TValue>, IComparable<TValue>
    {
        public GameEntityGenericAttributeType(string name, string description) : base(name, description) { }

        public GameEntityGenericAttributeType(string name) : base(name, name) { }

        public bool Equals(GameEntityGenericAttributeType<TValue> other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            var casted = obj as GameEntityGenericAttributeType<TValue>;

            return Equals(casted);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}

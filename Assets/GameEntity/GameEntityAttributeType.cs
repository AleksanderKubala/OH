using System;
using Assets.Common;

namespace Assets.GameEntity
{
    public class GameEntityAttributeType : DescribableObject, IEquatable<GameEntityAttributeType>
    {
        public GameEntityAttributeType(string name) : this(name, name) { }
        public GameEntityAttributeType(string name, string description) : base(name, description) { }

        public bool Equals(GameEntityAttributeType other)
        {
            if (other != null)
            {
                if (ReferenceEquals(this, other) || Name == other.Name)
                {
                    return true;
                }
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            var castedObj = obj as GameEntityAttributeType;

            return Equals(castedObj);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}

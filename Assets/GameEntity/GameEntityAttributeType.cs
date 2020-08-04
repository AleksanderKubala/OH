using System;
using Assets.Common;

namespace Assets.GameEntity
{
    public class GameEntityAttributeType : INamedObject, IEquatable<GameEntityAttributeType>
    {
        public GameEntityAttributeType(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

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

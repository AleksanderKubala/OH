using System;

namespace OHLogic.GameEntity
{
    public class GameEntityAttribute : IGameEntityAttribute
    {
        public GameEntityAttribute(GameEntityAttributeType attributeType)
        {
            AttributeType = attributeType ?? throw new ArgumentNullException(nameof(attributeType));
        }

        public GameEntityAttributeType AttributeType { get; protected set; }

        public bool Equals(IGameEntityAttribute other)
        {
            if(other == null)
            {
                return false;
            }

            var attributeTypeEquality = AttributeType.Equals(other.AttributeType);

            return attributeTypeEquality;
        }

        public override bool Equals(object obj)
        {
            var casted = obj as IGameEntityAttribute;

            return Equals(casted);
        }

        public override int GetHashCode()
        {
            return AttributeType.GetHashCode();
        }
    }
}

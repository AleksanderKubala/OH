using System;
using System.Collections.Generic;

namespace OHLogic.GameEntity
{
    public class GameEntityStatistics : IGameEntityStatistics
    {
        protected IDictionary<GameEntityAttributeType, IGameEntityAttribute> attributes;

        public void AddAttribute(IGameEntityAttribute attribute)
        {
            if(attribute == null) { throw new ArgumentNullException(nameof(attribute)); }

            attributes[attribute.AttributeType] = attribute;
        }

        public IGameEntityGenericAttribute<T> GetAttribute<T>(GameEntityGenericAttributeType<T> attributeType) where T : struct, IEquatable<T>, IComparable<T>
        {
            attributes.TryGetValue(attributeType, out var attribute);

            return attribute as IGameEntityGenericAttribute<T>;
        }

        public IGameEntityAttribute GetAttribute(GameEntityAttributeType attributeType)
        {
            attributes.TryGetValue(attributeType, out var attribute);

            return attribute;
        }
    }
}

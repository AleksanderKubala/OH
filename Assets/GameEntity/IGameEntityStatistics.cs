using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.GameEntity
{
    public interface IGameEntityStatistics
    {
        void AddAttribute(IGameEntityAttribute attribute);
        IGameEntityGenericAttribute<T> GetAttribute<T>(GameEntityGenericAttributeType<T> attributeType) where T : struct, IEquatable<T>, IComparable<T>;
        IGameEntityAttribute GetAttribute(GameEntityAttributeType attributeType);
    }
}

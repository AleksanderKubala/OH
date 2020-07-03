using System;
namespace OHLogic.GameEntity
{
    public interface IGameEntityAttribute: IEquatable<IGameEntityAttribute>
    {
        GameEntityAttributeType AttributeType { get; }
    }
}

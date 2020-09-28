using System;
namespace Assets.GameEntity
{
    public interface IGameEntityAttribute: IEquatable<IGameEntityAttribute>
    {
        GameEntityAttributeType AttributeType { get; }
    }
}

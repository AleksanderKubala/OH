using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OHLogic.Common;

namespace OHLogic.GameEntity
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

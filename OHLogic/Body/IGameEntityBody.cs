using System;
using System.Collections.Generic;
using OHLogic.GameEntity;

namespace OHLogic.Body
{
    public interface IGameEntityBody : IGameEntityOwned
    {
        float OverallCondition { get; }

        void AddBodypart(Bodypart bodypart);
        void RemoveBodypart(Bodypart bodypart);
        IEnumerable<Bodypart> GetBodyparts(Func<Bodypart, bool> predicate);
    }
}


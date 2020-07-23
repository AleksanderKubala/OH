using System;
using System.Collections.Generic;
using Assets.GameEntity;

namespace Assets.Body
{
    public interface IGameEntityBody : IGameEntityOwned
    {
        float OverallCondition { get; }

        void AddBodypart(Bodypart bodypart);
        void RemoveBodypart(Bodypart bodypart);
        IEnumerable<Bodypart> GetBodyparts(Func<Bodypart, bool> predicate);
    }
}


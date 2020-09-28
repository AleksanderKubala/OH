using System;
using UnityEngine;

namespace Assets.Factions
{
    [Serializable]
    public class Relation
    {
        IFaction sourceFaction;
        IFaction targetFaction;
        RelationAttitude attitude;
        [Min(1)]
        int importance;

        public Relation(IFaction source, IFaction target) : this(source, target, RelationAttitude.Neutral, 1)
        {
        }

        public Relation(IFaction source, IFaction target, RelationAttitude attitude, int importance)
        {
            this.attitude = attitude;
            this.importance = importance;
        }

        public RelationAttitude Attitude => attitude;
        public int Weight => importance;
    }
}

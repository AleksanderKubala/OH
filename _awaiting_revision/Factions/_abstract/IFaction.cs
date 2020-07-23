using System;
using System.Collections.Generic;

namespace Assets.Factions
{
    public interface IFaction
    {
        event EventHandler<IFaction> FactionAttitudeChanged;

        RelationAttitude AttitudeTowards(IFaction faction);
        ICollection<IFaction> GetAffiliatedFactions();
        bool IsPartOf(IFaction faction);
    }
}

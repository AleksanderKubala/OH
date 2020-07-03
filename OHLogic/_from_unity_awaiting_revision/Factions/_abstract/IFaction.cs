using System;
using System.Collections.Generic;

namespace OHLogic.Factions
{
    public interface IFaction
    {
        event EventHandler<IFaction> FactionAttitudeChanged;

        RelationAttitude AttitudeTowards(IFaction faction);
        ICollection<IFaction> GetAffiliatedFactions();
        bool IsPartOf(IFaction faction);
    }
}

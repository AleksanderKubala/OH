using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Factions
{
    public class CharacterFaction : MonoBehaviour, IFaction
    {
        public event EventHandler<IFaction> FactionAttitudeChanged;

        public RelationAttitude AttitudeTowards(IFaction faction)
        {
            if (ReferenceEquals(faction, this))
            {
                return RelationAttitude.Neutral;
            }

            return RelationAttitude.Enemy;
        }

        public ICollection<IFaction> GetAffiliatedFactions()
        {
            return new List<IFaction>(1) { this };
        }

        public bool IsPartOf(IFaction faction)
        {
            if (ReferenceEquals(faction, this))
            {
                return true;
            }

            return false;
        }
    }
}

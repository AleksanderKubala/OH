using System;
using UnityEngine.Events;

namespace OHLogic.Combat.Events
{
    [Serializable]
    public class AttackSpotted : UnityEvent<AttackAction>
    {
    }
}

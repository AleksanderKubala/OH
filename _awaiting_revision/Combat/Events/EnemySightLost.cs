using System;
using UnityEngine.Events;

namespace Assets.Combat.Events
{
    [Serializable]
    public class EnemySightLost : UnityEvent<EntityCombatController>
    {
    }
}

using System;
using UnityEngine.Events;

namespace Assets.Combat.Events
{
    [Serializable]
    public class EnemyAttackHit : UnityEvent<AttackAction>
    {
    }
}

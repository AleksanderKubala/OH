using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OHLogic.Combat;
using UnityEngine.Events;

namespace Assets.Combat.Events
{
    [Serializable]
    public class ReactedToAttacks : UnityEvent<List<AttackAction>>
    {
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using OHLogic.Common;

namespace Assets.Combat
{
    public interface ICombatStrategy : IListener
    {
        DefenceAction PrepareDefence(IEnumerable<AttackAction> attacksToDefend, IEnumerable<DefenceAction> availableDefences);
        AttackAction SelectAttack(EntityCombatController target, IEnumerable<AttackAction> availableAttacks);
        void DecideToAttack(Action callback);
        void StopDecidingAboutAttack();
        bool DecideToDefend(IEnumerable<AttackAction> attacksToDefend);
    }
}

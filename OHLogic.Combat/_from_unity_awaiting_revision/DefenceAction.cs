using System.Collections.Generic;
using System.Linq;
using OHLogic.Combat.Data;

namespace OHLogic.Combat
{
    public class DefenceAction : CombatAction<DefensiveActionData>
    {
        public DefenceAction(DefensiveActionData data)
        {
            ActionData = data;
            DefendedAttacks = new HashSet<AttackAction>();
        }
        public override DefensiveActionData ActionData {get; protected set; }
        public ISet<AttackAction> DefendedAttacks { get; private set; }

        public override void Attempt()
        {
            base.Attempt();
        }

        public override void Finish()
        {
            base.Finish();
        }

        public bool AddDefendedAttack(AttackAction attack)
        {
            if(DefendedAttacks.Count >= ActionData.MaximumDefensibleAttacks) 
            {
                return false;
            }

            DefendedAttacks.Add(attack);
            return true;
        }

        public bool AddDefendedAttack(IEnumerable<AttackAction> attacks)
        {
            var additionalAttacksPossibleToDefend =  ActionData.MaximumDefensibleAttacks - DefendedAttacks.Count;
            if (additionalAttacksPossibleToDefend <= 0) 
            {
                return false;
            }

            var attacksToAdd = attacks;
            if(additionalAttacksPossibleToDefend < attacks.Count())
            {
                attacksToAdd = attacks.Take(additionalAttacksPossibleToDefend);
            }

            foreach(var attack in attacksToAdd)
            {
                DefendedAttacks.Add(attack);
            }

            var allAttacksAdded = ReferenceEquals(attacksToAdd, attacks);

            return allAttacksAdded;
        }

        public void RemoveDefendedAttack(AttackAction attack)
        {
            DefendedAttacks.Remove(attack);
        }
    }
}

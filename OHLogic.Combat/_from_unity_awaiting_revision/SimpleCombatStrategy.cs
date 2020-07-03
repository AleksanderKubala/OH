using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OHLogic.Body;
using OHLogic.Combat.Data;
using OHLogic.Utils;
using UnityEngine;

namespace OHLogic.Combat
{
    public class SimpleCombatStrategy : ICombatStrategy
    {
        private EntityCombatController combatController;
        private Action attackDecisionCallback;
        private float? reactionTime;

        public SimpleCombatStrategy(EntityCombatController combatController)
        {
            this.combatController = combatController;
        }
        public void DecideToAttack(Action callback)
        {
            attackDecisionCallback = callback;
            reactionTime = combatController.RaceData.NextReactionTime;
        }

        public void StopDecidingAboutAttack()
        {
            attackDecisionCallback = null;
            reactionTime = null;
        }

        public bool DecideToDefend(IEnumerable<AttackAction> attacksToDefend)
        {
            return true;
        }

        public void Notify()
        {
            if(reactionTime.HasValue)
            {
                reactionTime -= Time.deltaTime;
                if (reactionTime <= 0)
                {
                    var trueProbability = -reactionTime.Value * 10;
                    if (Utility.RollUniform(trueProbability))
                    {
                        attackDecisionCallback?.Invoke();
                    }
                }
            }
        }

        public DefenceAction PrepareDefence(IEnumerable<AttackAction> attacksToDefend, IEnumerable<DefenceAction> availableDefences)
        {
            var attackToDefend = attacksToDefend.First();
            var selectedDefence = SelectDefence(attackToDefend, availableDefences);
            selectedDefence.AddDefendedAttack(attackToDefend);

            return selectedDefence;
        }

        public AttackAction SelectAttack(EntityCombatController target, IEnumerable<AttackAction> availableAttacks)
        {
            var performedAttack = Utility.SelectRandomlyFromEnumerable(availableAttacks);
            if(performedAttack != null && Utility.SelectRandomlyFromEnumerable(target.Body.BodyElements, out var bodypartName))
            {
                var enemyBodyparts = target.Body.GetBodypart(bodypartName.Value);
                performedAttack.Target = Utility.SelectRandomlyFromEnumerable(enemyBodyparts);
                performedAttack.SourceEntity = combatController;
            }

            return performedAttack;
        }

        private DefenceAction SelectDefence(AttackAction attack, IEnumerable<DefenceAction> availableDefences)
        {
            DefenceAction selectedDefence = null;
            List<DefensiveActionData> possibleDefences = attack.ActionData.PossibleDefences;
            int bestDefenceIndex = int.MaxValue, currentIndex;

            foreach (var defence in availableDefences)
            {
                if ((currentIndex = possibleDefences.IndexOf(defence.ActionData)) < bestDefenceIndex)
                {
                    bestDefenceIndex = currentIndex;
                    selectedDefence = defence;
                }
            }

            return selectedDefence;
        }
    }
}

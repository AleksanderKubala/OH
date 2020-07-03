using System;
using System.Collections;
using System.Collections.Generic;
using OHLogic.Actions;

namespace OHLogic.Combat
{
    public class DefendingCombatState : CombatState
    {
        private TargetingCombatState targetingState;

        public DefendingCombatState(EntityCombatController context) : base(context) { }

        public static DefendingCombatState Creator(EntityCombatController context)
        {
            return new DefendingCombatState(context);
        }

        public override void Enter()
        {
            base.Enter();
            StateContext.PerformedDefence.ActionFinished += OnDefenceFinished;
            StateContext.PerformedDefence.Attempt();
        }

        public override void Exit()
        {
            StateContext.PerformedDefence.ActionFinished -= OnDefenceFinished;
        }

        protected override void SolveAllReachableStates()
        {
            SolveSpecificReachableState(ref targetingState, TargetingCombatState.Creator);
        }

        private void OnDefenceFinished(object sender, IAction defence)
        {
            StateContext.ChangeState(this, targetingState);
        }
    }
}

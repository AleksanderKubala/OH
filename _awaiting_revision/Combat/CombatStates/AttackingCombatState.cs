using System;
using OHLogic.Actions;

namespace Assets.Combat
{
    public class AttackingCombatState : CombatState
    {
        private TargetingCombatState targetingState;
        private PursuingCombatState pursuingState;

        public AttackingCombatState(EntityCombatController context) : base(context) { }
        public static AttackingCombatState Creator(EntityCombatController context)
        {
            return new AttackingCombatState(context);
        }

        public override void Enter()
        {
            base.Enter();
            StateContext.PerformedAttack.ActionFinished += OnAttackFinished;
            StateContext.PerformedAttack.Attempt();
        }

        public override void Exit()
        {
            StateContext.PerformedAttack.ActionFinished -= OnAttackFinished;
            StateContext.ClearPerformedAttack();
        }

        protected override void SolveAllReachableStates()
        {
            SolveSpecificReachableState(ref targetingState, TargetingCombatState.Creator);
            SolveSpecificReachableState(ref pursuingState, PursuingCombatState.Creator);
        }

        private void OnAttackFinished(object sender, IAction action)
        {
            StateContext.ChangeState(this, targetingState);
        }
    }
}

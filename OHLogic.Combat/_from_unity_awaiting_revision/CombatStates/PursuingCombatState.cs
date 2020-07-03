using System;
using System.Collections;
using System.Collections.Generic;

namespace OHLogic.Combat
{
    public class PursuingCombatState : CombatState
    {
        private TargetingCombatState targetingState;
        private AttackingCombatState attackingState;
        private DefendingCombatState defendingState;

        public PursuingCombatState(EntityCombatController context) : base(context)
        {
            StateContext.ReactionToIncomingAttack += OnReactionToIncomingAttack;
            StateContext.CurrentTargetWithinRange += OnCurrentTargetWithinRange;
            StateContext.CurrentTargetOutsideRange += OnCurrentTargetOutsideRange;
            StateContext.CurrentTargetUnavailable += OnCurrentTargetUnavailable;
        }

        ~PursuingCombatState()
        {
            StateContext.ReactionToIncomingAttack -= OnReactionToIncomingAttack;
            StateContext.CurrentTargetWithinRange -= OnCurrentTargetWithinRange;
            StateContext.CurrentTargetOutsideRange -= OnCurrentTargetOutsideRange;
            StateContext.CurrentTargetUnavailable -= OnCurrentTargetUnavailable;
        }

        public static PursuingCombatState Creator(EntityCombatController context)
        {
            return new PursuingCombatState(context);
        }

        public override void Enter()
        {
            base.Enter();
            StateContext.RegisterTickListener(StateContext.CurrentCombatStrategy);
            StateContext.PursueTargetedEnemy();
            StateContext.SelectPerformedAttack();
        }

        public override void Exit()
        {
            base.Exit();
            StateContext.UnregisterTickListener(StateContext.CurrentCombatStrategy);
        }

        protected override void SolveAllReachableStates()
        {
            SolveSpecificReachableState(ref targetingState, TargetingCombatState.Creator);
            SolveSpecificReachableState(ref attackingState, AttackingCombatState.Creator);
            SolveSpecificReachableState(ref defendingState, DefendingCombatState.Creator);
        }

        private void OnReactionToIncomingAttack(object sender, IEnumerable<AttackAction> attacksReactedOn)
        {
            if(StateContext.CurrentState == this && StateContext.CurrentCombatStrategy.DecideToDefend(attacksReactedOn))
            {
                StateContext.PrepareDefence(attacksReactedOn);
                if(StateContext.PerformedDefence != null)
                {
                    StateContext.ChangeState(this, defendingState);
                }
            }
        }

        private void OnCurrentTargetWithinRange(object sender, EventArgs args)
        {
            if(StateContext.CurrentState == this)
            {
                StateContext.CurrentCombatStrategy.DecideToAttack(AttackDecidedCallback);
            }
        }

        private void OnCurrentTargetOutsideRange(object sender, EventArgs args)
        {
            if(StateContext.CurrentState == this)
            {
                StateContext.CurrentCombatStrategy.StopDecidingAboutAttack();
                StateContext.PursueTargetedEnemy();
            }
        }

        private void OnCurrentTargetUnavailable(object sender, EventArgs args)
        {
            if(StateContext.CurrentState == this)
            {
                StateContext.ChangeState(this, targetingState);
            }
        }

        private void AttackDecidedCallback()
        {
            if(StateContext.CurrentState == this)
            {
                StateContext.ChangeState(this, attackingState);
            }
        }
    }
}

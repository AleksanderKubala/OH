using OHLogic.Common;

namespace Assets.Combat
{
    public abstract class CombatState : AbstractContextualState<EntityCombatController>
    {
        public CombatState(EntityCombatController context) : base(context) { }

        public override EntityCombatController StateContext { get; protected set; }

        public override void Enter()
        {
            SolveAllReachableStates();
        }

        public override void Exit()
        {

        }

        public override void Proceed()
        {

        }
    }
}

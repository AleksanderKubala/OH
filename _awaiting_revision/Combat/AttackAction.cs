using OHLogic.Body;
using OHLogic.Combat.Data;

namespace Assets.Combat
{

    public class AttackAction : CombatAction<OffensiveActionData>
    {
        public AttackAction(OffensiveActionData data, AttackBox attackBox) : base()
        {
            ActionData = data;
            AttackBox = attackBox;
        }
        public override OffensiveActionData ActionData { get; protected set; }
        public EntityCombatController SourceEntity { get; set; }
        public IBodypart Target { get; set; }
        private AttackBox AttackBox { get; set; }

        public override void Attempt()
        {
            base.Attempt();
            AttackBox.Attack = this;
            AttackBox.Effective();
        }

        public override void Finish()
        {
            AttackBox.Attack = null;
            AttackBox.Ineffective();
            base.Finish();
        }

        public override void Cease()
        {
            base.Cease();
        }
    }
}

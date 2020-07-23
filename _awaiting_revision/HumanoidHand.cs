using System;
using OHLogic.Common.Data;

namespace Assets.Body
{
    public class HumanoidHand : Bodypart
    {
        private IBodypartData bodypartData;
        private AttackActionProvider attackProvider;
        private DefenceActionProvider defenceProvider;

        public AttackActionsGainedEvent AttacksGained;
        public DefenceActionsGainedEvent DefencesGained;

        public override BodypartData BodypartData => bodypartData;
    }
}

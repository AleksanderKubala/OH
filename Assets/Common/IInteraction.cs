using Asset.OnlyHuman.Characters;
using OHLogic.Common;

namespace Assets.Common
{
    public interface IInteraction : ICommand
    {
        void SetInteractionSourceAsTarget(EntityController entityInitiationInteraction);
    }
}

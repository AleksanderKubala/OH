using UnityEngine;

namespace Assets.Common
{
    public interface IGameAction
    {
        void Perform();
        Transform GetTarget();
    }
}

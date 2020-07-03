using System;
using OHLogic.DataObjects;
using OHLogic.GameEntity;

namespace OHLogic.Inventory
{
    public interface IPickupable : IGameEntityOwnershipTransferable
    {
        bool CanBeTaken(IGameEntity takingGameEntity);
        bool CanBeDropped();
        void WhenTaken();
        void WhenDropped();
    }
}

﻿using System;
using OHLogic.Body;
using OHLogic.Inventory;
using OHLogic.Items;

namespace OHLogic.GameEntity
{
    public interface IGameEntity
    {
        IGameEntityStatistics Statistics { get; }
        IGameEntityBody Body { get; }
        IInventory Inventory { get; }
        bool Equip(IItem item);
        bool Unequip(IItem item);
        bool PutToInventory(IItem item);
        bool Drop(IItem item);
    }
}

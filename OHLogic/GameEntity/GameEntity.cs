using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OHLogic.Body;
using OHLogic.Equipment;
using OHLogic.Inventory;
using OHLogic.Items;

namespace OHLogic.GameEntity
{
    public class GameEntity : IGameEntity
    {
        public IGameEntityStatistics Statistics { get; private set; }
        public IGameEntityBody Body { get; private set;}
        public IInventory Inventory { get; private set; }
        public IEquipment Equipment { get; set; }

        public GameEntity()
        {

        }

        public IGameEntityGenericAttribute<T> GetAttribute<T>(GameEntityGenericAttributeType<T> attributeType) where T : struct, IComparable<T>, IEquatable<T>
        {
            return Statistics.GetAttribute(attributeType);
        }

        public bool Equip(IItem item)
        {
            var relevantSlots = Equipment.GetEquipmentSlotsMatchingItem(item);
            throw new NotImplementedException();
        }

        public bool Unequip(IItem item)
        {
            throw new NotImplementedException();
        }

        public bool PutToInventory(IItem item)
        {
            throw new NotImplementedException();
        }

        public bool Drop(IItem item)
        {
            throw new NotImplementedException();
        }
    }
}

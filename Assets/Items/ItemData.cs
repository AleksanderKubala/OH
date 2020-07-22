using OHLogic.Body;
using OHLogic.Data;
using OHLogic.Items;
using UnityEngine;

namespace Assets.Items
{
    public class ItemData : ScriptableObject, IItemData
    {
        public ItemType ItemType => throw new System.NotImplementedException();
        public BodypartType RelevantBodypart => throw new System.NotImplementedException();
        public float Volume => throw new System.NotImplementedException();

        public IItem CreateItemInstance()
        {
            throw new System.NotImplementedException();
        }

        public float GetCarryingPerformanceCoefficient()
        {
            throw new System.NotImplementedException();
        }

        public float GetUsagePerformanceCoefficient()
        {
            throw new System.NotImplementedException();
        }
    }
}

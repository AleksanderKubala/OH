using Assets.Body;
using Assets.Data;
using UnityEngine;

namespace Assets.Items
{
    [CreateAssetMenu(fileName = "Item Data", menuName = "Items/Item Data")]
    public class ItemData : ScriptableObject, IItemData
    {
        public ItemType ItemType => throw new System.NotImplementedException();
        public BodypartType RelevantBodypart => throw new System.NotImplementedException();
        public float Volume => 0.0f;

        public IItem CreateItemInstance()
        {
            return new Item(this);
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

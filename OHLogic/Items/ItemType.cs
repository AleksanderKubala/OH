using System;
using System.Collections.Generic;
using OHLogic.Common;

namespace OHLogic.Items
{
    public class ItemType : DescribableObject, IType<ItemType>
    {
        public ItemType(string name, string description, HashSet<ItemType> itemSupertypes) : base(name, description)
        {
            if(itemSupertypes == null)
            {
                itemSupertypes = new HashSet<ItemType>();
            }

            LinkToParents(this, itemSupertypes);
        }

        public bool BelongsToType(ItemType itemType)
        {
            var belongsToGroup = this.Equals(itemType) || groupingDictionary[this].Contains(itemType);

            return belongsToGroup;
        }

        public bool Equals(ItemType other)
        {
            if(other != null)
            {
                if(ReferenceEquals(this, other) || (Name == other.Name))
                {
                    return true;
                }
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            var casted = obj as ItemType;

            return Equals(casted);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        #region Static

        private static readonly Dictionary<ItemType, HashSet<ItemType>> groupingDictionary;

        static ItemType()
        {
            groupingDictionary = new Dictionary<ItemType, HashSet<ItemType>>();
        }

        public static LinkedList<ItemType> FindGroupCycles()
        {
            var groupingsWithCycle = new LinkedList<ItemType>();

            foreach (var groupAndParents in groupingDictionary)
            {
                if (groupAndParents.Value.Contains(groupAndParents.Key))
                {
                    groupingsWithCycle.AddLast(groupAndParents.Key);
                }
            }

            return groupingsWithCycle;
        }

        private static void LinkToParents(ItemType group, HashSet<ItemType> parentGroups)
        {
            if (!groupingDictionary.TryGetValue(group, out var newGroupParents))
            {
                newGroupParents = new HashSet<ItemType>();
            }

            newGroupParents.UnionWith(parentGroups);

            foreach (var parentGroup in parentGroups)
            {
                if (groupingDictionary.TryGetValue(parentGroup, out var iteratedParents))
                {
                    newGroupParents.UnionWith(iteratedParents);
                }
            }
        }

        #endregion
    }
}

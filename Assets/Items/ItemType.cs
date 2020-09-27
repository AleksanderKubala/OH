using System.Collections.Generic;
using Assets.Common;
using Assets.GameEntity;

namespace Assets.Items
{
    public class ItemType : GameEntityType, IType<ItemType>
    {


        public bool BelongsToType(ItemType type)
        {
            return base.BelongsToType(type);
        }

        //public bool BelongsToType(ItemType itemType)
        //{
        //    var belongsToGroup = this.Equals(itemType) || GameObjectType.groupingDictionary[this].Contains(itemType);

        //    return belongsToGroup;
        //}

        //public bool Equals(ItemType other)
        //{
        //    if (other != null)
        //    {
        //        if (ReferenceEquals(this, other) || (Name == other.Name))
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}

        //public override bool Equals(object obj)
        //{
        //    var casted = obj as ItemType;

        //    return Equals(casted);
        //}

        //public override int GetHashCode()
        //{
        //    return Name.GetHashCode();
        //}

        //#region Static

        //private static readonly Dictionary<ItemType, HashSet<ItemType>> groupingDictionary;

        //static ItemType()
        //{
        //    groupingDictionary = new Dictionary<ItemType, HashSet<ItemType>>();
        //}

        //public static LinkedList<ItemType> FindGroupCycles()
        //{
        //    var groupingsWithCycle = new LinkedList<ItemType>();

        //    foreach (var groupAndParents in groupingDictionary)
        //    {
        //        if (groupAndParents.Value.Contains(groupAndParents.Key))
        //        {
        //            groupingsWithCycle.AddLast(groupAndParents.Key);
        //        }
        //    }

        //    return groupingsWithCycle;
        //}

        //private static void LinkToParents(ItemType group, HashSet<ItemType> parentGroups)
        //{
        //    if (!groupingDictionary.TryGetValue(group, out var newGroupParents))
        //    {
        //        newGroupParents = new HashSet<ItemType>();
        //    }

        //    newGroupParents.UnionWith(parentGroups);

        //    foreach (var parentGroup in parentGroups)
        //    {
        //        if (groupingDictionary.TryGetValue(parentGroup, out var iteratedParents))
        //        {
        //            newGroupParents.UnionWith(iteratedParents);
        //        }
        //    }
        //}

        //#endregion
    }
}

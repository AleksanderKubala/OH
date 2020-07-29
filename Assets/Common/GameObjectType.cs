using System.Collections.Generic;
using UnityEngine;

namespace Assets.Common
{
    public class GameObjectType : ScriptableObject, INamedObject,  IType<GameObjectType>
    {
        [SerializeField]
        private string _name;

        public string Name => _name;

        public bool BelongsToType(GameObjectType type)
        {
            var belongsToType = this.Equals(type) || groupingDictionary[this].Contains(type);

            return belongsToType;
        }
        public bool Equals(GameObjectType other)
        {
            if (other != null)
            {
                if (ReferenceEquals(this, other) || (Name == other.Name))
                {
                    return true;
                }
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            var casted = obj as GameObjectType;

            return Equals(casted);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        #region Static

        private static readonly Dictionary<GameObjectType, HashSet<GameObjectType>> groupingDictionary;

        static GameObjectType()
        {
            groupingDictionary = new Dictionary<GameObjectType, HashSet<GameObjectType>>();
        }

        public static LinkedList<GameObjectType> FindGroupCycles()
        {
            var groupingsWithCycle = new LinkedList<GameObjectType>();

            foreach (var groupAndParents in groupingDictionary)
            {
                if (groupAndParents.Value.Contains(groupAndParents.Key))
                {
                    groupingsWithCycle.AddLast(groupAndParents.Key);
                }
            }

            return groupingsWithCycle;
        }

        protected static void LinkToParents(GameObjectType group, HashSet<GameObjectType> parentGroups)
        {
            if (!groupingDictionary.TryGetValue(group, out var newGroupParents))
            {
                newGroupParents = new HashSet<GameObjectType>();
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

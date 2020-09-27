using System.Collections.Generic;
using System.Linq;
using Assets.GameEntity;
using UnityEngine;

namespace Assets.Managers
{
    public class GameEntityTypesManager : MonoBehaviour
    {
        private void Awake()
        {
            foreach (var type in groupingDictionary.Keys)
            {
                type.Init();
            }

            var cycles = FindGroupCycles();
            if (cycles.Any())
            {
                throw new System.Exception("Detected cycles in game entity types hierarchy");
            }
        }

        #region Static

        private static readonly Dictionary<GameEntityType, HashSet<GameEntityType>> groupingDictionary;

        static GameEntityTypesManager()
        {
            groupingDictionary = new Dictionary<GameEntityType, HashSet<GameEntityType>>();
        }

        public static void LinkToParents(GameEntityType group, HashSet<GameEntityType> parentGroups)
        {
            groupingDictionary.TryGetValue(group, out var groupParents);
            groupParents.UnionWith(parentGroups);

            foreach (var parentGroup in parentGroups)
            {
                if (groupingDictionary.TryGetValue(parentGroup, out var iteratedParents))
                {
                    groupParents.UnionWith(iteratedParents);
                }
            }
        }

        public static bool TypeHasParent(GameEntityType type, GameEntityType parent)
        {
            return groupingDictionary[type]?.Contains(parent) ?? false;
        }

        public static void RegisterType(GameEntityType type)
        {
            groupingDictionary[type] = new HashSet<GameEntityType>();
        }

        protected static LinkedList<GameEntityType> FindGroupCycles()
        {
            var groupingsWithCycle = new LinkedList<GameEntityType>();

            foreach (var groupAndParents in groupingDictionary)
            {
                if (groupAndParents.Value.Contains(groupAndParents.Key))
                {
                    groupingsWithCycle.AddLast(groupAndParents.Key);
                }
            }

            return groupingsWithCycle;
        }

        #endregion
    }
}

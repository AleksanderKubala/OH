using System;
using System.Collections.Generic;
using Assets.Common;

namespace Assets.Body
{
    public class BodypartType : DescribableObject, IType<BodypartType>
    {
        public BodypartType(string name, string description, HashSet<BodypartType> bodypartSupertypes) : base(name, description)
        {
            if(bodypartSupertypes == null)
            {
                bodypartSupertypes = new HashSet<BodypartType>();
            }

            LinkToParents(this, bodypartSupertypes);
        }

        public BodypartType(string name, string description) : this(name, description, new HashSet<BodypartType>()) { }

        public bool BelongsToType(BodypartType bodypartType)
        {
            var belongsToType = this.Equals(bodypartType) || BodypartType.groupingDictionary[this].Contains(bodypartType);

            return belongsToType;
        }

        public bool Equals(BodypartType other)
        {
            if(other != null)
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
            var casted = obj as BodypartType;

            return Equals(casted);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        #region Static

        private static readonly Dictionary<BodypartType, HashSet<BodypartType>> groupingDictionary;

        static BodypartType()
        {
            groupingDictionary = new Dictionary<BodypartType, HashSet<BodypartType>>();
        }

        public static LinkedList<BodypartType> FindGroupCycles()
        {
            var groupingsWithCycle = new LinkedList<BodypartType>();

            foreach (var groupAndParents in groupingDictionary)
            {
                if (groupAndParents.Value.Contains(groupAndParents.Key))
                {
                    groupingsWithCycle.AddLast(groupAndParents.Key);
                }
            }

            return groupingsWithCycle;
        }

        private static void LinkToParents(BodypartType linkedType, HashSet<BodypartType> supertypes)
        {
            if(linkedType == BodypartTypes.None || supertypes.Contains(BodypartTypes.None)) { throw new ArgumentException($"Bodypart type {BodypartTypes.None.Name} cannot be assigned neither as supertype nor subtype"); }

            if (!groupingDictionary.TryGetValue(linkedType, out var newGroupParents))
            {
                newGroupParents = new HashSet<BodypartType>();
            }

            newGroupParents.UnionWith(supertypes);

            foreach (var parentGroup in supertypes)
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

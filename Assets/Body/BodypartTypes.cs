using System;
using System.Linq;
using System.Text;

namespace Assets.Body
{
    public static partial class BodypartTypes
    {
        public static readonly BodypartType None = BodypartTypeNone.Instance;

        static BodypartTypes()
        {
            var groupsWithCycles = BodypartType.FindGroupCycles();

            if (groupsWithCycles.Any())
            {
                var joinedGroupsNames = new StringBuilder();
                foreach (var group in groupsWithCycles)
                {
                    joinedGroupsNames.Append(group.Name + " ");
                }

                throw new Exception($"Detected cycles for following bodypart type groups: {joinedGroupsNames}");
            }
        }
    }
}

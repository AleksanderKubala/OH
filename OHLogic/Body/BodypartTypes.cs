using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHLogic.Body
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

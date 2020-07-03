using System;
using System.Linq;
using System.Text;

namespace OHLogic.Items
{
    public static partial class ItemTypes
    {
        static ItemTypes()
        {
            var groupsWithCycles = ItemType.FindGroupCycles();

            if (groupsWithCycles.Any())
            {
                var joinedGroupsNames = new StringBuilder();
                foreach (var group in groupsWithCycles)
                {
                    joinedGroupsNames.Append(group.Name + " ");
                }

                throw new Exception($"Detected cycles for following bodypart types: {joinedGroupsNames}");
            }
        }
    }
}

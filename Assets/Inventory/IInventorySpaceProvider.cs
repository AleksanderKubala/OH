using System.Collections.Generic;

namespace Assets.Inventory
{
    public interface IInventorySpaceProvider
    {
        IEnumerable<IInventorySpace> GetInventorySpaces(); 
    }
}

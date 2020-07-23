using System.Collections.Generic;

namespace Assets.Body
{
    public sealed class BodypartTypeNone : BodypartType
    {
        public static readonly BodypartTypeNone Instance;

        static BodypartTypeNone()
        {
            if(Instance == null)
            {
                Instance = new BodypartTypeNone();
            }
        }

        private BodypartTypeNone() : base("None", "Can be used to depict item that game entities should not be able to equip" , new HashSet<BodypartType>()) { }
    }
}

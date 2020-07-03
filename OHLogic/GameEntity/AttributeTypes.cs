namespace OHLogic.GameEntity
{
    public static partial class AttributeTypes
    {
        public static readonly GameEntityGenericAttributeType<int> Strength;
        public static readonly GameEntityGenericAttributeType<int> Dexterity;
        public static readonly GameEntityGenericAttributeType<int> Intelligence;

        public static readonly GameEntityGenericAttributeType<float> Health;
        public static readonly GameEntityGenericAttributeType<float> Mana;

        static AttributeTypes()
        {
            Strength = new GameEntityGenericAttributeType<int>("Strength");
            Dexterity = new GameEntityGenericAttributeType<int>("Dexterity");
            Intelligence = new GameEntityGenericAttributeType<int>("Intelligence");

            Health = new GameEntityGenericAttributeType<float>("Health");
            Mana = new GameEntityGenericAttributeType<float>("Mana");
        }
    }
}

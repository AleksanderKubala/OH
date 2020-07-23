namespace Assets.Common
{
    public abstract class DescribableObject :IDescribable
    {
        public DescribableObject(string name, string desxription)
        {
            Name = name;
            Description = desxription;
        }

        public string Name { get; protected set; }
        public string Description { get; protected set; }
    }
}

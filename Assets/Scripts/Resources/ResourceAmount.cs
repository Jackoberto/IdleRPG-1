using UnityEditor;

namespace Resources
{
    [System.Serializable]
    public struct ResourceAmount
    {
        public Resource resourceType;
        public int amount;

        public ResourceAmount(Resource resourceType, int amount)
        {
            this.resourceType = resourceType;
            this.amount = amount;
        }

        public override string ToString()
        {
            return $"{amount} {resourceType.name}";
        }

        public bool IsAffordable => this.resourceType.ResourceAmount >= this.amount;

        public void Subtract(int value)
        {
            this.resourceType.ResourceAmount -= value;
        }

        public void Add(int value)
        {
            this.resourceType.ResourceAmount += value;
        }
    }
}
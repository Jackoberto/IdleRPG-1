namespace Resources
{
    [System.Serializable]
    public struct ResourceAmount
    {
        public Resource resourceType;
        public int amount;

        public override string ToString() => $"{amount} {resourceType.name}";

        public bool IsAffordable => this.resourceType.ResourceAmount >= this.amount;

        public void Subtract() => this.resourceType.ResourceAmount -= this.amount;

        public void Add() => this.resourceType.ResourceAmount += this.amount;
    }
}
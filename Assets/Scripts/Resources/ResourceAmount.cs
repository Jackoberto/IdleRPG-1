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
    }
}
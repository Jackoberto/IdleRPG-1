[System.Serializable]
public class ResourceAmount
{
    public Resource resourceType;
    public int amount;
    public int ResourceCount => resourceType.ResourceAmount;
}
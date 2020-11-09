using UnityEngine;

[CreateAssetMenu]
public class ProductionData : ScriptableObject {
	public ResourceAmount costs;
	[SerializeField] float costMultiplier = 1.1f;
	public ResourceAmount produce;
	public float productionTime = 1f;
	[SerializeField] float productionMultiplier = 1.05f;

	public ResourceAmount GetActualCosts(int amount) {
		var result = this.costs.amount * Mathf.Pow(this.costMultiplier, amount);
		var newCostResource = new ResourceAmount
		{
			resourceType = costs.resourceType, amount = Mathf.RoundToInt(result)
		};
		return newCostResource;
	}
	
	public ResourceAmount GetProductionAmount(int upgradeAmount) {
		var result = this.produce.amount * Mathf.Pow(this.productionMultiplier, upgradeAmount);
		var newProduceResource = new ResourceAmount
		{
			resourceType = produce.resourceType, amount = Mathf.RoundToInt(result)
		};
		return newProduceResource;
	}
}
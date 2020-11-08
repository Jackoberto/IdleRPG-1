using UnityEngine;

[CreateAssetMenu]
public class ProductionData : ScriptableObject { 
	[SerializeField] int costs = 100;
	public Resource costsResource;
	[SerializeField] float costMultiplier = 1.1f;
	public Resource producesResource;
	public float productionTime = 1f;
	[SerializeField] int productionAmount = 1;
	[SerializeField] float productionMultiplier = 1.05f;

	public int GetActualCosts(int amount) {
		var result = this.costs * Mathf.Pow(this.costMultiplier, amount);
		return Mathf.RoundToInt(result);
	}
	
	public int GetProductionAmount(int upgradeAmount) {
		var result = this.productionAmount * Mathf.Pow(this.productionMultiplier, upgradeAmount);
		return Mathf.RoundToInt(result);
	}
}
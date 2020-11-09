using Resources;
using UnityEngine;

namespace Clicker
{
	[CreateAssetMenu]
	public class ProductionData : ScriptableObject {
		public ResourceAmount costs;
		[SerializeField] float costMultiplier = 1.1f;
		public ResourceAmount produce;
		public float productionTime = 1f;
		[SerializeField] float productionMultiplier = 1.05f;

		public ResourceAmount GetActualCosts(int amount) {
			return new ResourceAmount(this.costs.resourceType, Mathf.RoundToInt(this.costs.amount * Mathf.Pow(this.costMultiplier, amount)));
		}
	
		public ResourceAmount GetProductionAmount(int upgradeAmount) {
			return new ResourceAmount(this.produce.resourceType, Mathf.RoundToInt(this.produce.amount * Mathf.Pow(this.costMultiplier, upgradeAmount)));
		}
	}
}
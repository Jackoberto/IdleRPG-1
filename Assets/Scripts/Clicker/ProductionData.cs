using System;
using Resources;
using UnityEngine;

namespace Clicker
{
	[CreateAssetMenu]
	public class ProductionData : ScriptableObject {
		[SerializeField] public ResourceAmount costs;
		[SerializeField] float costMultiplier = 1.1f;
		[SerializeField] private ResourceAmount produce;
		public float productionTime = 1f;
		[SerializeField] float productionMultiplier = 1.05f;

		public void SubscribeMeToCosts(Action method) => costs.resourceType.OnResourceChange += method;
		
		public ResourceAmount GetActualCosts(int amount) {
			var result = costs;
			result.amount = Mathf.RoundToInt(this.costs.amount * Mathf.Pow(this.costMultiplier, amount));
			return result;
		}
	
		public ResourceAmount GetProductionAmount(int upgradeAmount, int unitCount) {
			var result = produce;
			result.amount = Mathf.RoundToInt(result.amount * Mathf.Pow(this.productionMultiplier, upgradeAmount) * unitCount);
			return result;
		}
	}
}
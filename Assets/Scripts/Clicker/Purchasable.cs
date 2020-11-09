using System;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker
{
	[Serializable]
	public class Purchasable {
		public Text buttonLabel;
		ProductionData productionData;
		string productId;

		bool IsAffordable
		{
			get
			{
				var costAmount = this.productionData.GetActualCosts(this.Amount);
				return costAmount.resourceType.ResourceAmount >= costAmount.amount;
			}
		}

		public int Amount {
			get => PlayerPrefs.GetInt(this.productionData.name+"_"+this.productId, 0);
			private set => PlayerPrefs.SetInt(this.productionData.name+"_"+this.productId, value);
		}

		public void SetUp(ProductionData productionData, string productId) {
			this.productionData = productionData;
			this.productId = productId;
			UpdateCostLabel();
		}

		public void Purchase() {
			if (!this.IsAffordable) 
				return;
			var costAmount = this.productionData.GetActualCosts(this.Amount);
			costAmount.Subtract(costAmount.amount);
			this.Amount += 1;
			UpdateCostLabel();
		}

		public void Update() => UpdateTextColor();
		void UpdateTextColor() => this.buttonLabel.color = this.IsAffordable ? Color.black : Color.red;

		void UpdateCostLabel()
		{
			var costAmount = this.productionData.GetActualCosts(this.Amount);
			this.buttonLabel.text = $"Add {this.productId} for {costAmount}";
		}
	}
}
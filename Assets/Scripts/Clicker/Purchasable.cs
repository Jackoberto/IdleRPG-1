using System;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker
{
	[Serializable]
	public class Purchasable {
		public Text buttonLabel;
		public event Action OnPurchase;
		ProductionData productionData;
		string productId;

		private bool IsAffordable => productionData.GetActualCosts(this.Amount).IsAffordable;

		public int Amount {
			get => PlayerPrefs.GetInt(this.productionData.name+"_"+this.productId, 0);
			private set
			{
				PlayerPrefs.SetInt(this.productionData.name + "_" + this.productId, value); 
				OnPurchase?.Invoke();
			}
		}

		public void SetUp(ProductionData productionData, string productId) {
			this.productionData = productionData;
			this.productId = productId;
			productionData.SubscribeMeToCosts(UpdateTextColor);
			OnPurchase += UpdateCostLabel;
			OnPurchase?.Invoke();
			UpdateTextColor();
		}

		public void Purchase() {
			if (!this.IsAffordable) 
				return;
			this.productionData.GetActualCosts(this.Amount).Subtract();
			this.Amount += 1;
		}
		void UpdateTextColor() => this.buttonLabel.color = this.IsAffordable ? Color.black : Color.red;

		void UpdateCostLabel()
		{
			var costAmount = this.productionData.GetActualCosts(this.Amount);
			this.buttonLabel.text = $"Add {this.productId} for {costAmount}";
		}
	}
}
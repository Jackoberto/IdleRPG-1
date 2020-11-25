using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Clicker
{
	[Serializable]
	public class Purchasable {
		public UnityEvent<string> onButtonTextChange;
		public UnityEvent<Color> onButtonColorChange;
		public event Action OnPurchase;
		ProductionData productionData;
		string productId;

		private bool IsAffordable => productionData.GetActualCosts(this.Amount).IsAffordable;

		public int Amount {
			get => PlayerPrefs.GetInt(this.productionData.name+"_"+this.productId, 0);
			private set => PlayerPrefs.SetInt(this.productionData.name + "_" + this.productId, value);
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
			OnPurchase?.Invoke();
		}
		void UpdateTextColor() => this.onButtonColorChange.Invoke(this.IsAffordable ? Color.black : Color.red);

		void UpdateCostLabel()
		{
			var costAmount = this.productionData.GetActualCosts(this.Amount);
			this.onButtonTextChange.Invoke($"Add {this.productId} for {costAmount}");
		}
	}
}
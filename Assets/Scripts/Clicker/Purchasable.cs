using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Purchasable {
	public Text buttonLabel;
	ProductionData productionData;
	string productId;

	bool IsAffordable => productionData.costs.ResourceCount >= this.productionData.GetActualCosts(this.Amount).amount;

	public int Amount {
		get => PlayerPrefs.GetInt(this.productionData.name+"_"+this.productId, 0);
		private set => PlayerPrefs.SetInt(this.productionData.name+"_"+this.productId, value);
	}

	public void SetUp(ProductionData productionData, string productId) {
		this.productionData = productionData;
		this.productId = productId;
		this.buttonLabel.text = $"Add {productId} for {productionData.GetActualCosts(this.Amount).amount} {this.productionData.costs.resourceType.name}";
	}

	public void Purchase() {
		if (!this.IsAffordable) 
			return;
		this.productionData.GetActualCosts(this.Amount).resourceType.ResourceAmount -= this.productionData.GetActualCosts(this.Amount).amount;
		this.Amount += 1;
		this.buttonLabel.text = $"Add {this.productId} for {this.productionData.GetActualCosts(this.Amount).amount} {this.productionData.GetActualCosts(this.Amount).resourceType.name}";
	}

	public void Update() => UpdateTextColor();
	void UpdateTextColor() => this.buttonLabel.color = this.IsAffordable ? Color.black : Color.red;
}
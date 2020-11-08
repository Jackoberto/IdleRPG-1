using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Purchasable {
	public Text buttonLabel;
	ProductionData goldProductionData;
	private Resource resource;
	string productId;

	bool IsAffordable => goldProductionData.costsResource.ResourceAmount >= this.goldProductionData.GetActualCosts(this.Amount);

	public int Amount {
		get => PlayerPrefs.GetInt(this.goldProductionData.name+"_"+this.productId, 0);
		private set => PlayerPrefs.SetInt(this.goldProductionData.name+"_"+this.productId, value);
	}

	public void SetUp(ProductionData goldProductionData, Resource resource, string productId) {
		this.goldProductionData = goldProductionData;
		this.resource = resource;
		this.productId = productId;
		this.buttonLabel.text = $"Add {productId} for {goldProductionData.GetActualCosts(this.Amount)} {this.goldProductionData.costsResource.name}";
	}

	public void Purchase() {
		if (!this.IsAffordable) 
			return;
		this.resource.ResourceAmount -= this.goldProductionData.GetActualCosts(this.Amount);
		this.Amount += 1;
		this.buttonLabel.text = $"Add {this.productId} for {this.goldProductionData.GetActualCosts(this.Amount)} {this.resource.name}";
	}

	public void Update() => UpdateTextColor();
	void UpdateTextColor() => this.buttonLabel.color = this.IsAffordable ? Color.black : Color.red;
}
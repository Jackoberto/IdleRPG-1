using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Purchasable {
	public Text buttonLabel;
	ProductionData productionData;
	private Resource resource;
	string productId;

	bool IsAffordable => productionData.costsResource.ResourceAmount >= this.productionData.GetActualCosts(this.Amount);

	public int Amount {
		get => PlayerPrefs.GetInt(this.productionData.name+"_"+this.productId, 0);
		private set => PlayerPrefs.SetInt(this.productionData.name+"_"+this.productId, value);
	}

	public void SetUp(ProductionData productionData, Resource resource, string productId) {
		this.productionData = productionData;
		this.resource = resource;
		this.productId = productId;
		this.buttonLabel.text = $"Add {productId} for {productionData.GetActualCosts(this.Amount)} {this.productionData.costsResource.name}";
	}

	public void Purchase() {
		if (!this.IsAffordable) 
			return;
		this.resource.ResourceAmount -= this.productionData.GetActualCosts(this.Amount);
		this.Amount += 1;
		this.buttonLabel.text = $"Add {this.productId} for {this.productionData.GetActualCosts(this.Amount)} {this.resource.name}";
	}

	public void Update() => UpdateTextColor();
	void UpdateTextColor() => this.buttonLabel.color = this.IsAffordable ? Color.black : Color.red;
}
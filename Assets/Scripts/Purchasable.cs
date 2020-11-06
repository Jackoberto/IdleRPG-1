using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Purchasable {
	public Text buttonLabel;
	ProductionData _productionData;
	private Resource resource;
	string productId;

	bool IsAffordable => _productionData.costsResource.GoldAmount >= this._productionData.GetActualCosts(this.Amount);

	public int Amount {
		get => PlayerPrefs.GetInt(this._productionData.name+"_"+this.productId, 0);
		private set => PlayerPrefs.SetInt(this._productionData.name+"_"+this.productId, value);
	}

	public void SetUp(ProductionData productionData, Resource resource, string productId) {
		this._productionData = productionData;
		this.resource = resource;
		this.productId = productId;
		this.buttonLabel.text = $"Add {productId} for {productionData.GetActualCosts(this.Amount)} {this._productionData.costsResource.name}";
	}

	public void Purchase() {
		if (!this.IsAffordable) 
			return;
		this.resource.GoldAmount -= this._productionData.GetActualCosts(this.Amount);
		this.Amount += 1;
		this.buttonLabel.text = $"Add {this.productId} for {this._productionData.GetActualCosts(this.Amount)} {this.resource.name}";
	}

	public void Update() => UpdateTextColor();
	void UpdateTextColor() => this.buttonLabel.color = this.IsAffordable ? Color.black : Color.red;
}
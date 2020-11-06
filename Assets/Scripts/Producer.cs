using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Producer : MonoBehaviour {
	public ProductionData productionData;
	public Text goldAmountText;
	public ProductionPopUp popupPrefab;
	public Purchasable amount;
	public Purchasable upgrade;
	float elapsedTime;

	public void SetUp(ProductionData productionData) {
		this.productionData = productionData;
		this.gameObject.name = productionData.name;
		this.amount.SetUp(productionData, productionData.costsResource, "Count");
		this.upgrade.SetUp(productionData, productionData.costsResource, "Level");
	}

	public void Purchase() => this.amount.Purchase();
	public void Upgrade() => this.upgrade.Purchase();

	void Update() {
		UpdateProduction();
		UpdateTitleLabel();
		this.amount.Update();
		this.upgrade.Update();
	}

	void UpdateProduction() {
		this.elapsedTime += Time.deltaTime;
		if (this.elapsedTime >= this.productionData.productionTime) {
			ProduceGold();
			this.elapsedTime -= this.productionData.productionTime; // DO NOT SET TO ZERO HERE
		}
	}

	void UpdateTitleLabel() {
		this.goldAmountText.text = $"{this.amount.Amount}x {this.productionData.name} Level {this.upgrade.Amount}";
	}

	void ProduceGold() {
		if (this.amount.Amount == 0)
			return;
		productionData.producesResource.GoldAmount += Mathf.RoundToInt(CalculateProductionAmount());
		var instance = Instantiate(this.popupPrefab, this.transform);
		instance.GetComponent<Text>().text = $"+{CalculateProductionAmount()} {productionData.producesResource.name}";
	}

	float CalculateProductionAmount() {
		return this.productionData.GetProductionAmount(this.upgrade.Amount) * this.amount.Amount;
	}
}
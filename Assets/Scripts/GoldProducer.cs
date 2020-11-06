using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GoldProducer : MonoBehaviour {
	public GoldProductionData GoldProductionData;
	public Text goldAmountText;
	public ProductionPopUp popupPrefab;
	public Purchasable amount;
	public Purchasable upgrade;
	float elapsedTime;

	public void SetUp(GoldProductionData goldProductionData) {
		this.GoldProductionData = goldProductionData;
		this.gameObject.name = goldProductionData.name;
		this.amount.SetUp(goldProductionData, goldProductionData.costsResource, "Count");
		this.upgrade.SetUp(goldProductionData, goldProductionData.costsResource, "Level");
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
		if (this.elapsedTime >= this.GoldProductionData.productionTime) {
			ProduceGold();
			this.elapsedTime -= this.GoldProductionData.productionTime; // DO NOT SET TO ZERO HERE
		}
	}

	void UpdateTitleLabel() {
		this.goldAmountText.text = $"{this.amount.Amount}x {this.GoldProductionData.name} Level {this.upgrade.Amount}";
	}

	void ProduceGold() {
		if (this.amount.Amount == 0)
			return;
		GoldProductionData.producesResource.GoldAmount += Mathf.RoundToInt(CalculateProductionAmount());
		var instance = Instantiate(this.popupPrefab, this.transform);
		instance.GetComponent<Text>().text = $"+{CalculateProductionAmount()}";
	}

	float CalculateProductionAmount() {
		return this.GoldProductionData.GetProductionAmount(this.upgrade.Amount) * this.amount.Amount;
	}
}
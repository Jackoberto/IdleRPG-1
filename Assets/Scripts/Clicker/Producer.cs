using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Producer : MonoBehaviour {
	public ProductionData productionData;
	[FormerlySerializedAs("goldAmountText")] public Text resourceAmountText;
	public ProductionPopUp popupPrefab;
	[FormerlySerializedAs("amount")] public Purchasable count;
	public Purchasable upgrade;
	float elapsedTime;

	public void SetUp(ProductionData productionData) {
		this.productionData = productionData;
		this.gameObject.name = productionData.name;
		this.count.SetUp(productionData, "Count");
		this.upgrade.SetUp(productionData, "Level");
	}

	public void Purchase() => this.count.Purchase();
	public void Upgrade() => this.upgrade.Purchase();

	void Update() {
		UpdateProduction();
		UpdateTitleLabel();
		this.count.Update();
		this.upgrade.Update();
	}

	void UpdateProduction() {
		this.elapsedTime += Time.deltaTime;
		if (this.elapsedTime >= this.productionData.productionTime) {
			ProduceResource();
			this.elapsedTime -= this.productionData.productionTime; // DO NOT SET TO ZERO HERE
		}
	}

	void UpdateTitleLabel() {
		this.resourceAmountText.text = $"{this.count.Amount}x {this.productionData.name} Level {this.upgrade.Amount}";
	}

	void ProduceResource() {
		if (this.count.Amount == 0)
			return;
		productionData.produce.resourceType.ResourceAmount += Mathf.RoundToInt(CalculateProductionAmount());
		var instance = Instantiate(this.popupPrefab, this.transform);
		instance.GetComponent<Text>().text = $"+{CalculateProductionAmount()} {productionData.produce.resourceType.name}";
	}

	float CalculateProductionAmount() {
		return this.productionData.GetProductionAmount(this.upgrade.Amount).amount * this.count.Amount;
	}
}
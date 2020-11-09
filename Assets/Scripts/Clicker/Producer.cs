﻿using Common;
using Resources;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Clicker
{
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
			var productionAmount = this.productionData.GetProductionAmount(this.upgrade.Amount, this.count.Amount);
			print(productionAmount.amount + " calculated amount");
			print(count.Amount);
			productionAmount.resourceType.ResourceAmount += Mathf.RoundToInt(productionAmount.amount);
			var instance = Instantiate(this.popupPrefab, this.transform);
			instance.GetComponent<Text>().text = $"+{productionAmount}";
		}
	}
}
using UnityEngine;

public class GoldProductionSetup : MonoBehaviour {

	public GoldProductionData[] goldProductionUnits;
	public GoldProducer goldProductionUnitPrefab;

	void Start() {
		foreach (var productionUnit in this.goldProductionUnits) {
			var instance = Instantiate(this.goldProductionUnitPrefab, this.transform);
			instance.SetUp(productionUnit);
		}
	}
}
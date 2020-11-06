using UnityEngine;

public class ProductionSetup : MonoBehaviour {

	public ProductionData[] goldProductionUnits;
	public Producer productionUnitPrefab;

	void Start() {
		foreach (var productionUnit in this.goldProductionUnits) {
			var instance = Instantiate(this.productionUnitPrefab, this.transform);
			instance.SetUp(productionUnit);
		}
	}
}
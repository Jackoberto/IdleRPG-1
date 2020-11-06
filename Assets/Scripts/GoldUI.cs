using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour {
	public Text goldAmountText;
	public Resource[] resources;

	void UpdateGoldAmountLabel()
	{
		this.goldAmountText.text = "";
		foreach (var resource in resources)
		{
			this.goldAmountText.text += resource.GoldAmount.ToString($"0 {resource.name}") + "\n";
		}
	}

	void Update() {
		UpdateGoldAmountLabel();
	}
}

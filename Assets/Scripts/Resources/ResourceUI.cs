using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour {
	public Text resourceAmountText;
	public Resource resource;

	void UpdateGoldAmountLabel()
	{
		this.resourceAmountText.text = resource.GoldAmount.ToString($"0 {resource.name}");
	}

	void Update() {
		UpdateGoldAmountLabel();
	}
}

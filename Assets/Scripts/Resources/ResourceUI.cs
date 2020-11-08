using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour {
	public Text resourceAmountText;
	public Resource resource;

	void UpdateResourceAmountLabel()
	{
		this.resourceAmountText.text = resource.ResourceAmount.ToString($"0 {resource.name}");
	}

	void Update() {
		UpdateResourceAmountLabel();
	}
}
